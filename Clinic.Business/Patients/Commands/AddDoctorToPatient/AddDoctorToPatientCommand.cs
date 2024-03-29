using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Business.Patients.Commands.AddDoctorToPatient
{
    public record AddDoctorToPatientCommand(int PatientId, int DoctorId) : IRequest<Result>;

    public class AddDoctorToPatientCommandHandler : IRequestHandler<AddDoctorToPatientCommand, Result>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;

        public AddDoctorToPatientCommandHandler(IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result> Handle(AddDoctorToPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetById(request.PatientId);
            var doctor = await _doctorRepository.GetDoctorPersonById(request.DoctorId);

            if (patient == null || doctor == null)
            {
                return Result.Failure(Error.NotFound("Patient.NotFound", "Patient or doctor not found"));
            }

            if (await _patientRepository.IsDoctorAssociatedWithPatientAsync(request.PatientId, request.DoctorId))
            {
                return Result.Failure(Error.Conflit("Doctor.Conflict", "Patient is already associated with the specified doctor"));
            }

            var result = await _patientRepository.AddDoctorToPatientAsync(request.PatientId, request.DoctorId);

            return result ? Result.Success() : Result.Failure(Error.Validation("Unexpected","An unexpected error occurred while adding the doctor to the patient."));
        }
    }
}