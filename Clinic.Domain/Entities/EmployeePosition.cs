using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class EmployeePosition : AuditableEntity
{
    public string PositionaName { get; set; } = string.Empty;

    public Employee Employee { get; set; } = new();
}
