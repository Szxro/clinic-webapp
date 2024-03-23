using Clinic.Api.Extensions;
using Clinic.Business.DoctorsPosition.Commands.CreateDoctorPosition;
using Clinic.Business.DoctorsPosition.Query.GetAllDoctorPositions;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorPositionController : ControllerBase
    {
        private readonly ISender _sender;

        public DoctorPositionController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost("doctorposition/create")]

        public async Task<ActionResult> CreateDoctorPosition(CreateDoctorPositionCommand createDoctorPositionCommand)
        {
            Result result = await _sender.Send(createDoctorPositionCommand);

            return result.IsSuccess ? NoContent() : result.ToProblemDetails();
        }

        [HttpGet("doctorposition/all")]

        public async Task<ActionResult<PagedList<DoctorPositionDTO>>> GetAllDoctorsPosition(string? name,
                                                                           string? sortColumn,
                                                                           string? sortOrder,
                                                                           int page,
                                                                           int pageSize)
        {
            Result<PagedList<DoctorPositionDTO>> result = await _sender.Send(new GetAllDoctorPositionsQuery(name, sortColumn, sortOrder, page, pageSize));

            return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
        }
    }
}
