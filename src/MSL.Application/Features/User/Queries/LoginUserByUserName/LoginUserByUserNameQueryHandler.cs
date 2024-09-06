using MediatR;
using MLS.Application.Contracts.Identity;
using MLS.Application.Contracts.Logging;
using MLS.Application.Features.User.Queries.GetUserDetails;
using MLS.Application.Models.Identity;

namespace MLS.Application.Features.User.Queries.LoginUserByUserName;

public class LoginUserByUserNameQueryHandler : IRequestHandler<LoginUserByUserNameQuery, AuthResponse>
{
    private readonly IAuthService _authService;
    private readonly IAppLogger<GetUserDetailsQueryHandler> _logger;

    public LoginUserByUserNameQueryHandler(IAuthService authService, IAppLogger<GetUserDetailsQueryHandler> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public async Task<AuthResponse> Handle(LoginUserByUserNameQuery request, CancellationToken cancellationToken)
    {
        var response = await _authService.Login(request.model);

        _logger.LogInformation("User details by username {0} were retrieved successfully!", request.model.Username);
        return response;
    }
}