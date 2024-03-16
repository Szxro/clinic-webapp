using Clinic.Business.Contracts;
using Clinic.Data.Contracts;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using Clinic.Data.Errors;

namespace Clinic.Business.Doctors.Commands.CreateDoctor;

public record CreateDoctorCommand(string name,
                                  string telephone,
                                  string nif,
                                  int socialNumber,
                                  int collegueNumber,
                                  string startDate,
                                  string doctorPosition) : ICommand<Result>;

public class CreateDoctorCommandHandler : ICommandHandler<CreateDoctorCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDoctorPositionRepository _doctorPosition;
    private readonly IDoctorRepository _doctorRepository;

    public CreateDoctorCommandHandler(IUnitOfWork unitOfWork,
                                      IDoctorPositionRepository doctorPosition,
                                      IDoctorRepository doctorRepository)
    {
        _unitOfWork = unitOfWork;
        _doctorPosition = doctorPosition;
        _doctorRepository = doctorRepository;
    }

    public async Task<Result> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
    {
        DoctorPosition? doctorPosition = await _doctorPosition.GetDoctorPositionByPositionName(request.doctorPosition);

        if (doctorPosition is null)
        {
            return Result.Failure(DoctorPositionErrors.NotFoundByPositionName(request.doctorPosition));
        }

        _unitOfWork.ChangeContextTrackerToUnchanged(doctorPosition);

        Doctor doctor = new Doctor()
        {
            Person = new Person()
            {
                Name = request.name,
                Telephone = request.telephone,
                NIF = request.nif,
                SocialNumber = request.socialNumber,
            },
            CollegueNumber = request.collegueNumber,
            DoctorPosition = doctorPosition,
            StartDate = DateTime.UtcNow,
        };

        _doctorRepository.Add(doctor);

        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}
