using MediatR;
using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.DTO.User;
using MLS.Application.Features.User.Commands.RegisterUserCommand;
using MLS.Application.Features.User.Queries.GetUserDetailsByUserName;
using MLS.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace MLS.Api.Controllers;

public class AccountController : MatLidStoreBaseController
{
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
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
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<ActionResult<AppUser>> LoginUser([FromBody] LoginModel loginUser)
    {
        var user = await _mediator.Send(new GetUserDetailsByUserNameQuery(loginUser));
        return Ok(user);
    }
}