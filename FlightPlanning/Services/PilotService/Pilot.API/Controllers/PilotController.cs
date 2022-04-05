using MediatR;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Pilot.Application.Features.Models;
using Microsoft.AspNetCore.Authorization;
using Pilot.Application.Features.Queries.GetPilots;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Pilot.Application.Features.Commands.InsertPilot;
using Pilot.Application.Features.Commands.UpdatePilot;
using Pilot.Application.Features.Commands.DeletePilot;
using Pilot.Application.Features.Queries.GetSinglePilot;
using Pilot.Application.Features.Queries.FindUnscheduledPilots;

namespace Pilot.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class PilotController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PilotController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllPilots")]
        [ProducesResponseType(typeof(IEnumerable<PilotModel>), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<PilotModel>>> GetPilots()
        {
            var query = new GetPilotsQuery();

            var pilots = await _mediator.Send(query);

            return Ok(pilots);
        }

        [HttpGet("{employeeNumber}", Name = "GetSinglePiot")]
        [ProducesResponseType(typeof(PilotModel), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<PilotModel>> GetSinglePilot(string employeeNumber)
        {
            var query = new GetSinglePilotQuery(employeeNumber);

            var pilot = await _mediator.Send(query);

            return Ok(pilot);
        }

        [HttpGet(Name = "GetUnscheduledPilots")]
        [ProducesResponseType(typeof(IEnumerable<PilotModel>), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<PilotModel>>> GetUnscheduledPilots()
        {
            var query = new FindUnscheduledPilotsQuery();

            var freePilots = await _mediator.Send(query);

            return Ok(freePilots);
        }

        [HttpPost(Name = "InsertPilot")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> InsertPilot([FromBody] InsertPilotCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut(Name = "UpdatePilot")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> UpdatePilot([FromBody] UpdatePilotCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{employeeNumber}", Name = "DeletePilot")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeletePilot(string employeeNumber)
        {
            var command = new DeletePilotCommand() { EmployeeNumber = employeeNumber };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}