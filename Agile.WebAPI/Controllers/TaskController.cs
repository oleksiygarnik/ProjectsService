using Agile.Application.Tasks.Commands.AddTask;
using Agile.Application.Tasks.Commands.DeleteTask;
using Agile.Application.Tasks.Commands.UpdateTask;
using Agile.Application.Tasks.Queries;
using Agile.Application.Tasks.Queries.DTO;
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
    [Route("api/tasks")]
    public class TaskController : MediatorController
    {
        public TaskController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<TaskDto>))]
        public Task<IActionResult> GetTasks(TasksQuery query) => ExecuteQuery(query);

        [HttpGet("byUser/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<TaskDto>))]
        public Task<IActionResult> GetTasksByPerformerId(TasksByPerformerIdQuery query) => ExecuteQuery(query);

        [HttpGet("inProject/byUser/{Id}")] 
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(TasksCountByPerformerIdDto))]
        public Task<IActionResult> GetTasksInProjectByUserId(TasksCountByPerformerIdQuery query) => ExecuteQuery(query);

        [HttpGet("info/byUser/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<TaskShortInformationDto>))]
        public Task<IActionResult> GetTasksShortInfoByUserId(TasksByPerformerIdFilterQuery query) => ExecuteQuery(query);

        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(TaskDto))]
        public Task<IActionResult> GetTaskById(TaskByIdQuery query) => ExecuteQuery(query);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [Produces(typeof(int))]
        public async Task<IActionResult> AddTask([FromBody] AddTaskCommand command)
        {

            if (command is null)
                return BadRequest();

            var taskId = await _mediator.Send(command);

            return CreatedAtAction("AddTask", new { id = taskId });
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteTask(DeleteTaskCommand command)
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
        [Produces(typeof(TaskDto))]
        public async Task<IActionResult> UpdateTask([FromBody]  UpdateTaskCommand command)
        {
            if (command is null)
                return BadRequest();

            return Json(await _mediator.Send(command));
        }

    }
}
