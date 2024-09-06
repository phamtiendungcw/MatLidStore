using MediatR;
using Microsoft.Extensions.Logging;
using MLS.Application.Contracts.Identity;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Application.Models.Identity;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.RegisterUserCommand;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegistrationResponse>
{
    private readonly ILogger<RegisterUserCommandHandler> _logger;
    private readonly IAuthService _authService;

    public RegisterUserCommandHandler(IAuthService authService, ILogger<RegisterUserCommandHandler> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    public async Task<RegistrationResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new RegisterUserModelValidator();
        var validationResult = await validator.ValidateAsync(request.RegisterUser, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in register request for {0} - {1}.", nameof(AppUser), request);
            throw new BadRequestException("Invalid app user!", validationResult);
        }

        var response = await _authService.Register(request.RegisterUser);

        _logger.LogInformation("User was register successfully!");
        return response;
    }
}