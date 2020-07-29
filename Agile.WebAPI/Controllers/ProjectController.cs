using Agile.Application.Projects.Commands.AddProject;
using Agile.Application.Projects.Commands.DeleteProject;
using Agile.Application.Projects.Commands.UpdateProject;
using Agile.Application.Projects.Queries;
using Agile.Application.Users.Queries;
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
    [Route("api/projects")]
    public class ProjectController : MediatorController
    {
        public ProjectController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<ProjectDto>))]
        public Task<IActionResult> GetUsers(ProjectsQuery query) => ExecuteQuery(query);

        [HttpGet("info")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<ProjectDetailInformationDto>))]
        public Task<IActionResult> GetProjectsDetailInfortmation(ProjectsDetailInformationQuery query) => ExecuteQuery(query);


        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(UserDto))]
        public Task<IActionResult> GetProjectById(ProjectByIdQuery query) => ExecuteQuery(query);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [Produces(typeof(int))]
        public async Task<IActionResult> AddProject([FromBody] AddProjectCommand command)
        {
            if (command is null)
                return BadRequest();

            var projectId = await _mediator.Send(command);

            return CreatedAtAction("AddProject", new { id = projectId });
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteProject(DeleteProjectCommand command)
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
        [Produces(typeof(ProjectDto))]
        public async Task<IActionResult> UpdateProject([FromBody]  UpdateProjectCommand command)
        {
            if (command is null)
                return BadRequest();

            return Json(await _mediator.Send(command));
        }

    }
}
