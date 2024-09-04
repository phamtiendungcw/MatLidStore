using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.RegisterUserCommand;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
{
    private readonly ILogger<RegisterUserCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<RegisterUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new RegisterUserModelValidator();
        var validationResult = await validator.ValidateAsync(request.RegisterUser, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in register request for {0} - {1}.", nameof(AppUser), request.RegisterUser);
            throw new BadRequestException("Invalid app user!", validationResult);
        }

        var userToCreate = _mapper.Map<AppUser>(request.RegisterUser);
        await _userRepository.CreateAsync(userToCreate);

        _logger.LogInformation("User was register successfully!");
        return userToCreate.Id;
    }
}