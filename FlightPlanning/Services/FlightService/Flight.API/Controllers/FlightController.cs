using MediatR;
using System.Net;
using MassTransit;
using System.Threading.Tasks;
using EventBus.Messages.Events;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using FlightService.Application.Features.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FlightService.Application.Features.Queries.GetFlights;
using FlightService.Application.Features.Commands.InsertFlight;
using FlightService.Application.Features.Commands.UpdateFlight;
using FlightService.Application.Features.Commands.DeleteFlight;
using FlightService.Application.Features.Queries.GetSingleFlight;
using FlightService.Application.Features.Commands.ScheduleFlight;
using FlightService.Application.Features.Queries.GetUnscheduledFlights;

namespace Flight.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IPublishEndpoint _publish;

        public FlightController(IMediator mediator, IPublishEndpoint publish)
        {
            _mediator = mediator;
            _publish = publish;
        }

        [HttpGet(Name = "GetAllFlights")]
        [ProducesResponseType(typeof(IEnumerable<FlightModel>), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<FlightModel>>> GetFlights()
        {
            var query = new GetFlightsQuery();

            var flights = await _mediator.Send(query);

            return Ok(flights);
        }

        [HttpGet("{flightNumber}", Name = "GetSingleFlight")]
        [ProducesResponseType(typeof(IEnumerable<FlightModel>), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<FlightModel>>> GetSingleFlight(string flightNumber)
        {
            var query = new GetSingleFlightQuery(flightNumber);

            var flight = await _mediator.Send(query);

            return Ok(flight);
        }

        [HttpGet(Name = "GetUnscheduledFlights")]
        [ProducesResponseType(typeof(IEnumerable<FlightModel>), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<FlightModel>>> GetUnscheduledFlights()
        {
            var query = new GetUnscheduledFlightsQuery();

            var flights = await _mediator.Send(query);

            return Ok(flights);
        }

        [HttpPost(Name = "InsertFlight")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<FlightModel>> InsertFlight([FromBody] InsertFlightCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut(Name = "UpdateFlight")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> UpdateFlight([FromBody] UpdateFlightCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{flightNumber}", Name = "DeleteFlight")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteFlight(string flightNumber)
        {
            var command = new DeleteFlightCommand(flightNumber);

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut(Name = "ScheduleFlight")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> ScheduleFlight([FromBody] ScheduleFlightCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPost(Name = "CheckoutStaff")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CheckoutStaff([FromBody] ScheduleFlightCommand command)
        {
            #region örnek payload
            /*{
                    "flightNumber": "TK1027",
                    "captainId": "THY0649",
                    "coPilotId": "THY0892",
                    "seniorCrewId": "THY1009",
                    "crew1Id": "THY7502",
                    "crew2Id": "THY6251",
                    "crew3Id": "THY9387"
                }*/ 
            #endregion

            var hasSchedule = true;

            var crewIds = new List<string>() { command.SeniorCrewId, command.Crew1Id, command.Crew2Id, command.Crew3Id };

            var crewCheckoutEvent = new CrewCheckoutEvent() { EmployeeNumbers = crewIds, HasSchedule = hasSchedule };

            await _publish.Publish(crewCheckoutEvent);

            var pilotIds = new List<string> { command.CoPilotId, command.CaptainId };

            var pilotCheckoutEvent = new PilotCheckoutEvent() { EmployeeNumbers = pilotIds, HasSchedule = hasSchedule };

            await _publish.Publish(pilotCheckoutEvent);

            return Accepted();
        }
    }
}