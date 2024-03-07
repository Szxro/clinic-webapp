﻿using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class PersonVacationPeriod : AuditableEntity
{
    public Person Person { get; set; } = new();

    public int PersonId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public VacationPeriodStatus VacationPeriodStatus { get; set; } = new();

    public int VacationPeriodStatusId { get; set; }
}
