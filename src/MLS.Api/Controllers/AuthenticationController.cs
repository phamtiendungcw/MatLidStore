using Microsoft.AspNetCore.Mvc;
using MLS.Api.Controllers.BaseController;
using MLS.Application.Contracts.Identity;
using MLS.Application.Models.Identity;

namespace MLS.Api.Controllers;

public class AuthenticationController : MatLidStoreBaseController
{
    private readonly IAuthService _authenticationService;

    public AuthenticationController(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authenticationService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Login(RegistrationRequest request)
    {
        return Ok(await _authenticationService.Register(request));
    }
}