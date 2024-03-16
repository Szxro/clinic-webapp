using Clinic.Business.Doctors.Commands.CreateDoctor;
using Clinic.Business.DoctorsPosition.Query.GetDoctorPositionByPositionNameQuery;
using Clinic.Data.Entities;
using Clinic.Data.Entities.Common.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMediator _mediator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost("doctor/register")]

        public async Task<ActionResult<Result<string>>> CreateNewDoctor(CreateDoctorCommand createDoctor)
        {
            var result = await _mediator.Send(createDoctor);

            return result.IsSuccess ? Ok() : BadRequest(result.Error);
        }

        [HttpGet("doctorPosition/getByPositionName")]

        public async Task<ActionResult<Result<DoctorPosition>>> GetDoctorPositionByPositionName(string doctorPosition)
        {
            var result = await _mediator.Send(new GetDoctorPositionByPositionNameQuery(doctorPosition));

            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
        }
    }
}
