using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Business.Patients.Query.GetPatientInformation
{
    public record GetPatientInformationQuery(int patientId) : IQuery<Result<PatientDto>>;


   
    
       
    
}
