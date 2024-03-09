using Clinic.Data.Common;

namespace Clinic.Data.Entities;

public class DoctorConsult : AuditableEntity
{
    public Doctor Doctor { get; set; } = new();

    public int DoctorId { get; set; }

    public DateTime Date { get; set; }

    public DateTime Hour { get; set; }
}
