using Asp.Versioning;
using Clinic.Api.Extensions;
using Clinic.Business.PersonVacationPeriods.Commands.CreatePersonVacationPeriod;
using Clinic.Data.Common;
using Clinic.Data.DTOs;
using Clinic.Data.Entities.Common.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers;

[ApiVersion(1)]
[Route("api/v{v:apiVersion}/person-vacation-periods")]
[ApiController]
public class PersonVacationPeriodController : ControllerBase
{
    private readonly ISender _sender;

    public PersonVacationPeriodController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult> CreatePersonVacationPeriod(CreatePersonVacationPeriodCommand createPersonVacationPeriod)
    {
        Result result = await _sender.Send(createPersonVacationPeriod);
        return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    }

    //[HttpPut("{id}")]
    //public async Task<ActionResult> UpdatePersonVacationPeriod(int id, UpdatePersonVacationPeriodCommand command)
    //{
    //    if (id != command.PersonVacationPeriodId)
    //    {
    //        return BadRequest();
    //    }

    //    Result result = await _sender.Send(command);
    //    return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    //}

    //[HttpDelete("{id}")]
    //public async Task<ActionResult> DeletePersonVacationPeriod(int id)
    //{
    //    Result result = await _sender.Send(new DeletePersonVacationPeriodCommand(id));
    //    return result.IsSuccess ? NoContent() : result.ToProblemDetails();
    //}

    //[HttpGet]
    //public async Task<ActionResult<PagedList<PersonVacationPeriodResponse>>> GetPersonVacationPeriods(
    //    [FromQuery] int personId,
    //    [FromQuery] string? sortColumn,
    //    [FromQuery] string? sortOrder,
    //    [FromQuery] int page = 1,
    //    [FromQuery] int pageSize = 10)
    //{
    //    Result<PagedList<PersonVacationPeriodResponse>> result = await _sender.Send(
    //        new GetPersonVacationPeriodsQuery(personId, sortColumn, sortOrder, page, pageSize));

    //    return result.IsSuccess ? Ok(result.Data) : result.ToProblemDetails();
    //}
}