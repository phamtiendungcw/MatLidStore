using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IAppLogger<UpdateUserCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IAppLogger<UpdateUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.User, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(AppUser), request.User);
            throw new BadRequestException("Invalid app user!", validationResult);
        }

        var userToUpdate = _mapper.Map<AppUser>(request.User);
        await _userRepository.UpdateAsync(userToUpdate);

        _logger.LogInformation("User was updated successfully!");
        return Unit.Value;
    }
}