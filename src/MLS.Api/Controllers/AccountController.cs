using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.User;
using MLS.Application.Features.User.Commands.RegisterUserCommand;
using MLS.Application.Features.User.Queries.GetUserDetailsByUserName;
using System.Security.Cryptography;
using System.Text;

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
    public async Task<ActionResult> RegisterUser([FromBody] RegisterUserCommand user)
    {
        try
        {
            using (var hmac = new HMACSHA512())
            {
                user.RegisterUser.PasswordSalt = hmac.Key;
                var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(user.RegisterUser.Password));
                user.RegisterUser.PasswordHash = Convert.ToBase64String(hashedPassword);
            }

            var response = await _mediator.Send(user);
            return CreatedAtAction(nameof(RegisterUser), new { id = response });
        }
        catch (InvalidOperationException e)
        {
            return new BadRequestObjectResult(new { e.Message });
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<UserDetailsDto>> LoginUser([FromBody] LoginModel loginUser)
    {
        var user = await _mediator.Send(new GetUserDetailsByUserNameQuery(loginUser));
        return Ok(user);
    }
}