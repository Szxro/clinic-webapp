using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Business.Doctors.Query.GetDoctorsInformation;

public record GetDoctorsInformationQuery(string? name,
                                         string? sortColumn,
                                         string? sortOrder,
                                         int page,
                                         int pageSize) : IQuery<Result<PagedList<DoctorDto>>>;

public class GetDoctorsInformationQueryHandler : IQueryHandler<GetDoctorsInformationQuery, Result<PagedList<DoctorDto>>>
{
    private readonly IDoctorRepository _doctorRepository;

    public GetDoctorsInformationQueryHandler(IDoctorRepository doctorRepository)
    {
        _doctorRepository = doctorRepository;
    }

    public async Task<Result<PagedList<DoctorDto>>> Handle(GetDoctorsInformationQuery request, CancellationToken cancellationToken)
    {
        PagedList<DoctorDto> result = await _doctorRepository.GetDoctorsInformation(request.name, request.sortColumn, request.sortOrder, request.page, request.pageSize);

        return Result<PagedList<DoctorDto>>.Sucess(result);
    }
}
