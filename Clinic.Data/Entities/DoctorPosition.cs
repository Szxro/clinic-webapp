using Clinic.Data.Common;

namespace Clinic.Data.Entities;

public class DoctorPosition : AuditableEntity
{
    public string PositionName { get; set; } = string.Empty;

    public Doctor Doctor { get; set; } = new();
}
