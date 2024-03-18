using Clinic.Business.Contracts;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Errors;


namespace Clinic.Business.Doctors.Commands.UpdateDoctor
{
   public record UpdateDoctorCommand(
       int doctorId,
       string name,
       string telephone,
       string nif,
       int socialNumber,
       int collegueNumber,
       string startDate,
       string doctorPosition) : ICommand<Result>;
       
    public class UpdateDoctorCommandHandler : ICommandHandler<UpdateDoctorCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDoctorPositionRepository _doctorPosition;
        private readonly IDoctorRepository _doctorRepository;

        public UpdateDoctorCommandHandler(IUnitOfWork unitOfWork, IDoctorPositionRepository doctorPosition, IDoctorRepository doctorRepository)
        {
            _unitOfWork = unitOfWork;
            _doctorPosition = doctorPosition;
            _doctorRepository = doctorRepository;
        }

        public async Task<Result> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
        {
            DoctorPosition? doctorPosition = await _doctorPosition.GetDoctorPositionByPositionName(request.doctorPosition);

            if (doctorPosition is null)
            {
                return Result.Failure(DoctorPositionErrors.NotFoundByPositionName(request.doctorPosition));
            }

            _unitOfWork.ChangeContextTrackerToUnchanged(doctorPosition);

            Doctor doctor = await _doctorRepository.GetDoctorByIdAsync(request.doctorId);

            if (doctor is null)
            {
                return Result.Failure(DoctorErrors.NotFoundById(request.doctorId));
            }

            doctor.Person.Name = request.name;
            doctor.Person.Telephone = request.telephone;
            doctor.Person.NIF = request.nif;
            doctor.Person.SocialNumber = request.socialNumber;
            doctor.CollegueNumber = request.collegueNumber;
            doctor.DoctorPosition = doctorPosition;
            doctor.StartDate = DateTime.UtcNow;

            await _doctorRepository.AddAsync(doctor);

            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }   
}
