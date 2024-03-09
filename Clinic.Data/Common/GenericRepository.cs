using Clinic.Data.Entities.Common;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Clinic.Data.Common;

public abstract class GenericRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly AppDbContext _dbContext;

    public GenericRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(ICollection<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
    }

    public async Task<TEntity?> GetById(int Id)
    {
        return await _dbContext.Set<TEntity>().Where(x => x.Id == Id).FirstOrDefaultAsync();
    }

    public async Task<int?> DeleteBy(Expression<Func<TEntity, bool>> filter)
    {
        return await _dbContext.Set<TEntity>().Where(filter).ExecuteDeleteAsync();
    }

    public async Task<int?> UpdateBy(Expression<Func<TEntity, bool>> filter,
                                     Expression<Func<SetPropertyCalls<TEntity>, SetPropertyCalls<TEntity>>> propertiesExpression)
    {
        return await _dbContext.Set<TEntity>().Where(filter).ExecuteUpdateAsync(propertiesExpression);
    }
}
