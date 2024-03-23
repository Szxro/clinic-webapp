using Clinic.Data.Contracts;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;

namespace Clinic.Business.DoctorsPosition.Query.GetAllDoctorPositions;

public record GetAllDoctorPositionsQuery(string? name,
                                         string? sortColumn,
                                         string? sortOrder,
                                         int page,
                                         int pageSize) : IQuery<Result<PagedList<DoctorPositionDTO>>>;

public class GetAllDoctorPositionQueryHandler : IQueryHandler<GetAllDoctorPositionsQuery, Result<PagedList<DoctorPositionDTO>>>
{
    private readonly IDoctorPositionRepository _doctorPositionRepository;

    public GetAllDoctorPositionQueryHandler(IDoctorPositionRepository doctorPositionRepository)
    {
        _doctorPositionRepository = doctorPositionRepository;
    }

    public async Task<Result<PagedList<DoctorPositionDTO>>> Handle(GetAllDoctorPositionsQuery request, CancellationToken cancellationToken)
    {
       PagedList<DoctorPositionDTO> result = await _doctorPositionRepository.GetAllDoctorPositions(request.name,request.sortColumn,request.sortOrder,request.page,request.pageSize);

        return Result<PagedList<DoctorPositionDTO>>.Sucess(result);
    }
}
