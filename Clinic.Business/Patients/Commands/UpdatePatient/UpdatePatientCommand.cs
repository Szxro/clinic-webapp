using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Errors;
using System.Threading;
using System.Threading.Tasks;

namespace Clinic.Business.Patients.Commands
{
    public record UpdatePatientCommand(
        int patientId,
        string name,
        string telephone) : ICommand<Result>;

    public class UpdatePatientCommandHandler : ICommandHandler<UpdatePatientCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPatientRepository _patientRepository;

        public UpdatePatientCommandHandler(IUnitOfWork unitOfWork, IPatientRepository patientRepository)
        {
            _unitOfWork = unitOfWork;
            _patientRepository = patientRepository;
        }

        public async Task<Result> Handle(UpdatePatientCommand request, CancellationToken cancellationToken)
        {
            Patient? patient = await _patientRepository.GetPatientById(request.patientId);

            if (patient is null)
            {
                return Result.Failure(PatientErrors.NotFoundById(request.patientId));
            }

            patient.Person.Name = request.name;
            patient.Person.Telephone = request.telephone;

            _patientRepository.Update(patient);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
