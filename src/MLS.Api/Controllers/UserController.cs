using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.User;
using MLS.Application.Features.User.Commands.CreateUserCommand;
using MLS.Application.Features.User.Commands.DeleteUserCommand;
using MLS.Application.Features.User.Commands.UpdateUserCommand;
using MLS.Application.Features.User.Queries.GetAllUsers;
using MLS.Application.Features.User.Queries.GetUserDetails;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MLS.Api.Controllers;

public class UserController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<UserController>
    [AllowAnonymous]
    [HttpGet]
    public async Task<IReadOnlyList<UserDto>> GetAllUsers()
    {
        var users = await _mediator.Send(new GetAllUsersQuery());
        return users;
    }

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UserDetailsDto>> GetUser(int id)
    {
        var user = await _mediator.Send(new GetUserDetailsQuery(id));
        return Ok(user);
    }

    // POST api/<UserController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand user)
    {
        var response = await _mediator.Send(user);
        return CreatedAtAction(nameof(CreateUser), new { id = response });
    }

    // PUT api/<UserController>/5
    [HttpPut]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand user)
    {
        await _mediator.Send(user);
        return NoContent();
    }

    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var command = new DeleteUserCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}