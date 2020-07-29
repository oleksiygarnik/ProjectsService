using Agile.Application.Teams.Commands.AddTeam;
using Agile.Application.Teams.Commands.DeleteTeam;
using Agile.Application.Teams.Commands.UpdateTeam;
using Agile.Application.Teams.Queries;
using Agile.WebAPI.Controllers.Abstract;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Agile.WebAPI.Controllers
{
    [Route("api/teams")]
    public class TeamController : MediatorController
    {
        public TeamController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<TeamDTO>))]
        public Task<IActionResult> GetTeams(TeamsQuery query) => ExecuteQuery(query);

        [HttpGet("info")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<TeamDTO>))]
        public Task<IActionResult> GetFullInfoOfTeams(TeamsOrderedAndSortedQuery query) => ExecuteQuery(query);

        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(TeamDTO))]
        public Task<IActionResult> GetTeamById(TeamByIdQuery query) => ExecuteQuery(query);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [Produces(typeof(int))]
        public async Task<IActionResult> AddTeam([FromBody] AddTeamCommand command)
        {

            if (command is null)
                return BadRequest();

            var teamId = await _mediator.Send(command);

            return CreatedAtAction("AddTeam", new { id = teamId });
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteTeam(DeleteTeamCommand command)
        {
            if (command is null)
                return BadRequest();

            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut()]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(TeamDTO))]
        public async Task<IActionResult> UpdateTeam([FromBody]  UpdateTeamCommand command)
        {
            if (command is null)
                return BadRequest();

            return Json(await _mediator.Send(command));
        }

    }
}
