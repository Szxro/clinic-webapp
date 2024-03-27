using Clinic.Business.Patients.Commands.DeletePatient;
using FluentValidation;

namespace Clinic.Business.Patients.Validators
{
    public class DeletePatientValidator : AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientValidator()
        {
            RuleFor(command => command.patientId)
                .NotEmpty().WithMessage("Patient ID is required.");
        }
    }
}
