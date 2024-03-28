using Clinic.Api.Extensions;
using Clinic.Business.DoctorsConsult.Commands.CreateDoctorConsult;
using Clinic.Business.DoctorsConsult.Commands.DeleteDoctorConsult;
using Clinic.Business.DoctorsConsult.Commands.UpdateDoctorConsult;
using Clinic.Business.DoctorsConsult.Query.GetAllDoctorConsults;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorConsultController : ControllerBase
{
    private readonly ISender _sender;

    public DoctorConsultController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("doctorconsult/create")]

    public async Task<ActionResult> CreateDoctorConsult(CreateDoctorConsultCommand createDoctorConsult)
    {
        Result result = await _sender.Send(createDoctorConsult);

        return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    }

    [HttpPut("doctorconsult/update")]

    public async Task<ActionResult> UpdateDoctorConsult(UpdateDoctorConsultCommand updateDoctorConsult)
    {
        Result result = await _sender.Send(updateDoctorConsult);

        return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    }

    [HttpDelete("doctorconsult/delete")]

    public async Task<ActionResult> DeleteDoctorConsult(DeleteDoctorConsultCommand deleteDoctorConsult)
    {
        Result result = await _sender.Send(deleteDoctorConsult);

        return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    }

    [HttpGet("doctorconsult/all")]

    public async Task<ActionResult<PagedList<DoctorConsultResponse>>> GetAllDoctorConsults(string? name,
                                                                           string? sortColumn,
                                                                           string? sortOrder,
                                                                           int page,
                                                                           int pageSize)
    {
        Result<PagedList<DoctorConsultResponse>> result = await _sender.Send(new GetAllDoctorConsultsQuery(name,sortColumn,sortOrder,page,pageSize));

        return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
    }
}
