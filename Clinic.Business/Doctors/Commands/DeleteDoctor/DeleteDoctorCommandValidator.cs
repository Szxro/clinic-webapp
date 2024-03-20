using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Business.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandValidator: AbstractValidator<DeleteDoctorCommand>
    {
        public DeleteDoctorCommandValidator() 
        { 
            RuleFor(x => x.DoctorId)
                .GreaterThan(0)
                .WithMessage("The property {PropertyName} must be above zero.");
        
        }

    }
}
