using MediatR;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CrewService.Application.Features.Queries.Models;
using CrewService.Application.Features.Queries.GetCrews;
using CrewService.Application.Features.Commands.InsertCrew;
using CrewService.Application.Features.Commands.UpdateCrew;
using CrewService.Application.Features.Commands.DeleteCrew;
using CrewService.Application.Features.Queries.GetSingleCrew;
using CrewService.Application.Features.Queries.FindSeniorStaff;

namespace Crew.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class CrewController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CrewController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCrews")]
        [ProducesResponseType(typeof(IEnumerable<CrewModel>), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<CrewModel>>> GetCrews()
        {
            var query = new GetCrewQuery();

            var crews = await _mediator.Send(query);

            return Ok(crews);
        }

        [HttpGet("{employeeNumber}", Name = "GetSingleCrew")]
        [ProducesResponseType(typeof(CrewModel), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<CrewModel>> GetSingleCrew(string employeeNumber)
        {
            var query = new GetSingleCrewQuery(employeeNumber);

            var crew = await _mediator.Send(query);

            return Ok(crew);
        }

        [HttpGet(Name = "GetSeniorCrews")]
        [ProducesResponseType(typeof(IEnumerable<CrewModel>), (int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<IEnumerable<CrewModel>>> GetSeniorCrews()
        {
            var query = new FindSeniorStaffQuery();

            var seniorCrews = await _mediator.Send(query);

            return Ok(seniorCrews);
        }

        [HttpPost(Name = "InsertCrew")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<string>> InsertCrew([FromBody] InsertCrewCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpPut(Name = "UpdateCrew")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> UpdateCrew([FromBody] UpdateCrewCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("{id}", Name = "DeleteOrder")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<bool>> DeleteCrew(string id)
        {
            var command = new DeleteCrewCommand() { ID = id };

            var result = await _mediator.Send(command);

            return Ok(result);
        }
    }
}