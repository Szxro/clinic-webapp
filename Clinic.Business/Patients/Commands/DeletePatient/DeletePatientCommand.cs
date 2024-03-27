using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Errors;

namespace Clinic.Business.Patients.Commands.DeletePatient;

public record DeletePatientCommand(int patientId) : ICommand<Result>;

public class DeletePatientCommandHandler : ICommandHandler<DeletePatientCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPatientRepository _patientRepository;

    public DeletePatientCommandHandler(IUnitOfWork unitOfWork,
                                       IPatientRepository patientRepository)
    {
        _unitOfWork = unitOfWork;
        _patientRepository = patientRepository;
    }

    public async Task<Result> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
    {
        Patient? patient = await _patientRepository.GetById(request.patientId);

        if (patient is null)
        {
            return Result.Failure(PatientErrors.NotFoundPatients);
        }

        _patientRepository.Remove(patient);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
