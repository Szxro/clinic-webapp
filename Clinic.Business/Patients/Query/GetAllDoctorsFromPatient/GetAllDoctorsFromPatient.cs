using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Business.Patients.Queries.GetAllDoctorsFromPatient
{
    public record GetAllDoctorsFromPatientQuery(int PatientId) : IRequest<Result<IEnumerable<DoctorResponse>>>;

    public class GetAllDoctorsFromPatientQueryHandler : IRequestHandler<GetAllDoctorsFromPatientQuery, Result<IEnumerable<DoctorResponse>>>
    {
        private readonly IPatientRepository _patientRepository;

        public GetAllDoctorsFromPatientQueryHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public async Task<Result<IEnumerable<DoctorResponse>>> Handle(GetAllDoctorsFromPatientQuery request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetById(request.PatientId);
            if (patient == null)
            {
                return Result<IEnumerable<DoctorResponse>>.Failure(Error.NotFound("Patient.NotFound", "Patient not found"));
            }

            var doctors = await _patientRepository.GetAllDoctorsFromPatient(request.PatientId);
            return Result<IEnumerable<DoctorResponse>>.Sucess(doctors!);
        }
    }
}
