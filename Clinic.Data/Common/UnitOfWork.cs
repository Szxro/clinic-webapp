using Clinic.Data.Contracts;
using Clinic.Data.Entities.Common;
using Clinic.Data.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appDbContext;
    private readonly IPublisher _publisher;

    public UnitOfWork(AppDbContext appDbContext,
                      IPublisher publisher)
    {
        _appDbContext = appDbContext;
        _publisher = publisher;
    }

    public void ChangeContextTracker(object entity, EntityState entityState)
    {
        _appDbContext.Entry(entity).State = entityState;
    }

    public void ChangeContextTrackerToUnchanged(object entity)
    {
        _appDbContext.Entry(entity).State = EntityState.Unchanged;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        IEvent[] events = _appDbContext.ChangeTracker.Entries<BaseEntity>()
                                                  .Select(e => e.Entity)
                                                  .Where(e => e.events.Any())
                                                  .SelectMany(e => e.events)
                                                  .ToArray();

        int result = await _appDbContext.SaveChangesAsync(cancellationToken);

        foreach (IEvent @event in events)
        {
            await _publisher.Publish(@event);
        }

        return result;
    }
}
