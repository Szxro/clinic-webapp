using Clinic.Data.Common;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Data.Repositories;

public class PersonVacationPeriodRepository : GenericRepository<PersonVacationPeriod>, IPersonVacationPeriodRepository
{
    public PersonVacationPeriodRepository(AppDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<PersonVacationPeriod?> GetByIdWithDetailsAsync(int id)
    {
        return await _dbContext.Set<PersonVacationPeriod>()
            .Include(pvp => pvp.Person)
            .Include(pvp => pvp.VacationPeriodStatus)
            .FirstOrDefaultAsync(pvp => pvp.Id == id);
    }

    public async Task<List<PersonVacationPeriod>> GetByPersonIdAsync(int personId)
    {
        return await _dbContext.Set<PersonVacationPeriod>()
            .Include(pvp => pvp.Person)
            .Include(pvp => pvp.VacationPeriodStatus)
            .Where(pvp => pvp.PersonId == personId)
            .ToListAsync();
    }

    public async Task AddPersonVacationPeriodAsync(PersonVacationPeriod personVacationPeriod)
    {
        await _dbContext.Set<PersonVacationPeriod>().AddAsync(personVacationPeriod);
    }

    public void UpdatePersonVacationPeriod(PersonVacationPeriod personVacationPeriod)
    {
        _dbContext.Set<PersonVacationPeriod>().Update(personVacationPeriod);
    }

    public void DeletePersonVacationPeriod(PersonVacationPeriod personVacationPeriod)
    {
        _dbContext.Set<PersonVacationPeriod>().Remove(personVacationPeriod);
    }

}