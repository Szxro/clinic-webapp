using Clinic.Data.Entities.Common.Primitives;


namespace Clinic.Data.Errors
{
    public class DoctorErrors
    {
        public static Error NotFoundById(int doctorId) 
            => Error.NotFound("Doctor.NotFoundById",$"The doctor with the id of {doctorId} was not found");

        public static Error CollegueNumberNotUnique(int collegueNumber)
            => Error.Conflit("Doctor.CollegueNumberConflit",$"The doctor collegue number {collegueNumber} already exists");

        public static Error NotFoundByName(string doctorName)
            => Error.NotFound("Doctor.NotFoundById", $"The doctor with the id of {doctorName} was not found");

        public static readonly Error NotFoundDoctors 
            = Error.NotFound("Doctor.NotFound","Currently there are not doctors register");

    }
}
