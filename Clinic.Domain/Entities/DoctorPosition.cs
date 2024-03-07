using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class DoctorPosition : AuditableEntity
{
    public string PositionName { get; set; } = string.Empty;

    public Doctor Doctor { get; set; } = new();
}
