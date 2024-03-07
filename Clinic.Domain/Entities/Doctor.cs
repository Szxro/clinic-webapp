using Clinic.Domain.Common;

namespace Clinic.Domain.Entities;

public class Doctor : AuditableEntity
{
    public Doctor()
    {
        DoctorConsults = new HashSet<DoctorConsult>();
        DoctorPatients = new HashSet<DoctorPatient>();
    }

    public int CollegueNumber { get; set; } // TODO: Unique Constraint

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public Person Person { get; set; } = new(); // One to One

    public int PersonId { get; set; }

    public DoctorPosition DoctorPosition { get; set; } = new(); // One to One

    public int DoctorPositionId { get; set; }

    public ICollection<DoctorConsult> DoctorConsults { get; set; } // One to Many

    public ICollection<DoctorPatient> DoctorPatients { get; set; } // One to Many
}
