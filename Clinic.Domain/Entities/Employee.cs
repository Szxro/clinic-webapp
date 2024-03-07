﻿using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class Employee : AuditableEntity
{
    public Person Person { get; set; } = new(); // One to One

    public int PersonId { get; set; }

    public EmployeePosition EmployeePosition { get; set; } = new(); // One to One

    public int EmployeePositionId { get; set; }
}