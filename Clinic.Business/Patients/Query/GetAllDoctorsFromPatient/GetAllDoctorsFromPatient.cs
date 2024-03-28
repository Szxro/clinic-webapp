using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Business.Patients.Query.GetPatientInformation
{
    public record GetAllDoctorsFromPatientQuery(int patientId) : IRequest<Result<List<DoctorResponse>>>;

    public class GetAllDoctorsFromPatientQueryHandler : IRequestHandler<GetAllDoctorsFromPatientQuery, Result<List<DoctorResponse>>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllDoctorsFromPatientQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result<List<DoctorResponse>>> Handle(GetAllDoctorsFromPatientQuery request, CancellationToken cancellationToken)
        {
            List<DoctorResponse?> doctors = await _patientRepository.GetAllDoctorsFromPatient(request.patientId);

            List<DoctorResponse> validDoctors = doctors.Where(d => d != null).Select(d => d!).ToList();

            return Result<List<DoctorResponse>>.Sucess(validDoctors);
        }
    }
}
