using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly ILogger<CreateUserCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, ILogger<CreateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.User, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}", nameof(AppUser), request.User);
            throw new BadRequestException("Invalid app user!", validationResult);
        }

        var userToCreate = _mapper.Map<AppUser>(request.User);
        await _userRepository.CreateAsync(userToCreate);

        _logger.LogInformation("User was created successfully!");
        return userToCreate.Id;
    }
}