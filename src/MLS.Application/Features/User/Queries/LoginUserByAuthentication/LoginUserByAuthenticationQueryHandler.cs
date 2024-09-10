using MediatR;
using MLS.Application.Contracts.Identity;
using MLS.Application.Contracts.Logging;
using MLS.Application.Features.User.Queries.GetUserDetails;
using MLS.Application.Models.Identity;

namespace MLS.Application.Features.User.Queries.LoginUserByAuthentication;

public class LoginUserByAuthenticationQueryHandler : IRequestHandler<LoginUserByAuthenticationQuery, AuthResponse>
{
    private readonly IAuthService _authService;
    private readonly IAppLogger<GetUserDetailsQueryHandler> _logger;

    public LoginUserByAuthenticationQueryHandler(IAuthService authService, IAppLogger<GetUserDetailsQueryHandler> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public async Task<AuthResponse> Handle(LoginUserByAuthenticationQuery request, CancellationToken cancellationToken)
    {
        var response = await _authService.Login(request.model);

        _logger.LogInformation("User details by username {0} were retrieved successfully!", request.model.Username);
        return response;
    }
}