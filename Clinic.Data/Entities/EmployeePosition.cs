using Clinic.Data.Entities.Common;

namespace Clinic.Data.Entities;

public class EmployeePosition : AuditableEntity
{
    public string PositionaName { get; set; } = string.Empty;

    public Employee Employee { get; set; } = new();
}
