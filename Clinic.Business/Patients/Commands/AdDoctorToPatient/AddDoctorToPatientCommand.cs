using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Business.Patients.Commands.AdDoctorToPatient
{
    public record AddDoctorToPatientCommand(
        int patientId,
               int doctorId
           ) : ICommand<Result>;

    public class AddDoctorToPatientCommandHandler : IRequestHandler<AddDoctorToPatientCommand, Result>
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly AppDbContext _dbContext;

        public AddDoctorToPatientCommandHandler(IPatientRepository patientRepository, IDoctorRepository doctorRepository, AppDbContext dbContext)
        {
            _patientRepository = patientRepository;
            _doctorRepository = doctorRepository;
            _dbContext = dbContext;
        }

        public async Task<Result> Handle(AddDoctorToPatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientRepository.GetById(request.patientId);
            var doctor = await _doctorRepository.GetDoctorPersonById(request.doctorId);

            if (patient == null || doctor == null)
            {
                return Result.Failure((Error.NotFound("Patient.NotFound", "Patient/Doctor not found")));
            }

            if (patient.DoctorPatients.Any(dp => dp.DoctorId == request.doctorId))
            {
                return Result.Failure(Error.Conflit("Doctor.Conflict","Patient is already associated with the specified doctor"));
            }

            var doctorPatient = new DoctorPatient
            {
                PatientId = request.patientId,
                DoctorId = request.doctorId
            };

            _dbContext.Attach(patient);

            patient.DoctorPatients.Add(doctorPatient);

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }

}
