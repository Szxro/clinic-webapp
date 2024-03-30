﻿using Clinic.Data.Common;
using Clinic.Data.Entities;

namespace Clinic.Data.Contracts;

public interface IPersonVacationPeriodRepository 
{
    Task<PersonVacationPeriod?> GetByIdWithDetailsAsync(int id);
    Task<List<PersonVacationPeriod>> GetByPersonIdAsync(int personId);
    Task AddPersonVacationPeriodAsync(PersonVacationPeriod personVacationPeriod);
    void UpdatePersonVacationPeriod(PersonVacationPeriod personVacationPeriod);
    void DeletePersonVacationPeriod(PersonVacationPeriod personVacationPeriod);
}
