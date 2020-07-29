using Agile.Application.Users.Commands.AddUserCommand;
using Agile.Application.Users.Commands.DeleteUserCommand;
using Agile.Application.Users.Commands.UpdateUserCommand;
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
    [Route("api/users")]
    public class UserController : MediatorController
    {
        public UserController(IMediator mediator) : base(mediator)
        {

        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<UserDto>))]
        public Task<IActionResult> GetUsers(UsersQuery query) => ExecuteQuery(query);

        [HttpGet("order")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(IEnumerable<UserDto>))]
        public Task<IActionResult> GetUsersWithTasks(UsersOrderingQuery query) => ExecuteQuery(query);

        [HttpGet("info/{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(UserDetailInformationDto))]
        public Task<IActionResult> GetUserInformationFullById(UserByIdDetailInformationQuery query) => ExecuteQuery(query);


        [HttpGet("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [Produces(typeof(UserDto))]
        public Task<IActionResult> GetUserById(UserByIdQuery query) => ExecuteQuery(query);

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [Produces(typeof(int))]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            if (command is null)
                return BadRequest();

            var userId = await _mediator.Send(command);

            return CreatedAtAction("AddUser", new { id = userId });
        }

        [HttpDelete("{Id}")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
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
        [Produces(typeof(UserDto))]
        public async Task<IActionResult> UpdateUser([FromBody]  UpdateUserCommand command)
        {
            if (command is null)
                return BadRequest();

            return Json(await _mediator.Send(command));
        }

    }
}
