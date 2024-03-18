using Clinic.Data.Contracts;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Entities;
using Clinic.Data.Errors;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Business.Doctors.Commands.DeleteDoctor
{
    public record DeleteDoctorCommand(int DoctorId) : IRequest<Result>;

    public class DeleteDoctorCommandHandler : IRequestHandler<DeleteDoctorCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorRepository _doctorRepository;

        public DeleteDoctorCommandHandler(IUnitOfWork unitOfWork, IDoctorRepository doctorRepository)
        {
            _unitOfWork = unitOfWork;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result> Handle(DeleteDoctorCommand request, CancellationToken cancellationToken)
        {
            Doctor doctor = await _doctorRepository.GetById(request.DoctorId);

            if (doctor is null)
            {
                return Result.Failure(DoctorErrors.NotFoundById(request.DoctorId));
            }

            _doctorRepository.Delete(doctor);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
