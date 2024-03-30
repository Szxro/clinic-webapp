using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Data.Errors;

public static class DoctorPatientErrors
{
    public static readonly Error AlreadyAssociatedPatient
         = Error.Conflit("DoctorPatient.Conflict", "Patient or the Doctor is already associated");
}
