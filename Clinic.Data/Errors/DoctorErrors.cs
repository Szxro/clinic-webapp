using Clinic.Data.Entities.Common.Primitives;


namespace Clinic.Data.Errors
{
    public class DoctorErrors
    {
        public static Error NotFoundById(int doctorId) 
            => Error.NotFound("Doctor.NotFoundById",$"The doctor with the id of {doctorId} was not found");
    }
}
