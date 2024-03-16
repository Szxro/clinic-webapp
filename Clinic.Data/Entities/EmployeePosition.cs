using Clinic.Data.Entities.Common;

namespace Clinic.Data.Entities;

public class EmployeePosition : AuditableEntity
{
    public string PositionName { get; set; } = string.Empty;

    public Employee? Employee { get; set; }
}
