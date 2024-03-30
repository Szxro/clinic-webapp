using Clinic.Data.Entities;

namespace Clinic.Data.Contracts;

public interface IVacationPeriodStatus
{
    Task AddDefaultVacationPeriodStatus();
    Task<VacationPeriodStatus?> GetById(int id);
    Task AddPersonVacationPeriodAsync(PersonVacationPeriod personVacationPeriod);
    void UpdatePersonVacationPeriod(PersonVacationPeriod personVacationPeriod);
    void DeletePersonVacationPeriod(PersonVacationPeriod personVacationPeriod);
}
