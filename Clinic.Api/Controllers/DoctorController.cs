﻿using Clinic.Api.Extensions;
using Clinic.Business.Doctors.Commands.CreateDoctor;
using Clinic.Business.Doctors.Commands.DeleteDoctor;
using Clinic.Business.Doctors.Commands.UpdateDoctor;
using Clinic.Business.Doctors.Query.GetDoctorsInformation;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
    private readonly ISender _sender;

    public DoctorController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost("doctor/create")]

    public async Task<ActionResult> CreateDoctor(CreateDoctorCommand createDoctor)
    {
        Result result = await _sender.Send(createDoctor);

        return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    }

    [HttpDelete("doctor/remove")]

    public async Task<ActionResult> DeleteDoctor(DeleteDoctorCommand deleteDoctor)
    {
        Result result = await _sender.Send(deleteDoctor);

        return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    }

    [HttpPut("doctor/update")]

    public async Task<ActionResult> UpdateDoctor(UpdateDoctorCommand updateDoctor)
    {
        Result result = await _sender.Send(updateDoctor);

        return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    }

    [HttpGet("doctor/all")]

    public async Task<ActionResult<PagedList<DoctorResponse>>> GetDoctorsInformation(string? name,
                                                                           string? sortColumn,
                                                                           string? sortOrder,
                                                                           int page,
                                                                           int pageSize)
    {
        Result<PagedList<DoctorResponse>> result = await _sender.Send(new GetDoctorsInformationQuery(name,sortColumn,sortOrder,page,pageSize));

        return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
    }
}
