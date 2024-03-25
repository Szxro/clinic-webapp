using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Data.Errors
{
    public class PatientErrors
    {
        public static Error NotFoundById(int patientId)
            => Error.NotFound("Patient.NotFoundById", $"The patient with the id of {patientId} was not found");

        public static Error NotFoundByName(string patientName)
            => Error.NotFound("Patient.NotFoundByName", $"The patient with the name {patientName} was not found");

        public static readonly Error NotFoundPatients
            = Error.NotFound("Patient.NotFound", "Currently there are no patients registered");
    }
}
