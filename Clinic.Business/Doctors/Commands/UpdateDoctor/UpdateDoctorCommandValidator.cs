using FluentValidation;
using System.Globalization;


namespace Clinic.Business.Doctors.Commands.UpdateDoctor
{
    public class DoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public DoctorCommandValidator()
        {
            RuleFor(c => c.doctorId)
            .GreaterThan(0)
            .WithMessage("The property {PropertyName} must be above zero.");

            RuleFor(c => c.name)
                .NotNull()
                .NotEmpty()
                .WithMessage("The property {PropertyName} cannot be empty.");

            RuleFor(c => c.telephone)
                .NotNull()
                .NotEmpty()
                .WithMessage("The property {PropertyName} cannot be empty.");

            RuleFor(c => c.startDate)
               .Must(startDate => DateTime.TryParse(startDate, DateTimeFormatInfo.CurrentInfo, out DateTime _))
               .When(c => !string.IsNullOrEmpty(c.startDate))
               .WithMessage("The {PropertyName} is not a valid date");

            RuleFor(c => c.doctorPosition)
                .NotNull()
                .NotEmpty()
                .WithMessage("The property {PropertyName} cannot be empty.");
        }
    }
}
