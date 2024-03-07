﻿using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class DoctorPatient : AuditableEntity
{
    public Doctor Doctor { get; set; } = new();

    public int DoctorId { get; set; }

    public Patient Patient { get; set; } = new();

    public int PatientId { get; set; }
}
