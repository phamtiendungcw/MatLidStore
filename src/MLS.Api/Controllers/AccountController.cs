using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Features.User.Commands.RegisterUserCommand;
using MLS.Application.Features.User.Queries.LoginUserByUserName;
using MLS.Application.Models.Identity;

namespace MLS.Api.Controllers;

[AllowAnonymous]
public class AccountController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult> RegisterUser([FromBody] RegisterUserCommand user)
    {
        var response = await _mediator.Send(user);
        return CreatedAtAction(nameof(RegisterUser), new { id = response });
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AuthResponse>> LoginUser([FromBody] AuthRequest loginUser)
    {
        var user = await _mediator.Send(new LoginUserByUserNameQuery(loginUser));
        return Ok(user);
    }
}