using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories;

public class PersonRepository
    : GenericRepository<Person>,
    IPersonRepository
{
    public PersonRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<bool> IsNifNotAvaliable(string nif)
    {
        return await _dbContext.Person.AsNoTracking().AnyAsync(x => x.NIF == nif);
    }

    public async Task<bool> IsSocialNumberNotAvaliable(int socialNumber)
    {
        return await _dbContext.Person.AsNoTracking().AnyAsync(x => x.SocialNumber == socialNumber);
    }
}
