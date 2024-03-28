using Clinic.Data.Entities.Common;

namespace Clinic.Data.Entities;

public class DoctorPosition : AuditableEntity
{
    public DoctorPosition()
    {
        Doctors = new HashSet<Doctorresponse>();
    }

    public string PositionName { get; set; } = string.Empty;

    public ICollection<Doctorresponse> Doctors { get; set; }
}
