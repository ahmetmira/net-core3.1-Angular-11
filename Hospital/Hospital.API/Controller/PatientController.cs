using Hospital.Application.Requests.PatientServices.Commands.CreatePatient;
using Hospital.Application.Requests.PatientServices.Commands.DeletePatient;
using Hospital.Application.Requests.PatientServices.Commands.UpdatePatient;
using Hospital.Application.Requests.PatientServices.Queries.GetAllPatients;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Hospital.API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients([FromQuery] GetAllPatientsQuery query)

        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePatientQuery query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeletePatientQuery(id));

            return Ok(result);
        }
    }
}
