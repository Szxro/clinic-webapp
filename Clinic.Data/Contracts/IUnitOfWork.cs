using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Contracts;

public interface IUnitOfWork
{
    void ChangeContextTracker(object entity, EntityState entityState);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
