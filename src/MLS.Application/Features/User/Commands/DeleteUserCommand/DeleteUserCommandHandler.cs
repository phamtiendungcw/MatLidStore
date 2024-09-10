using MediatR;
using Microsoft.Extensions.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.DeleteUserCommand;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly ILogger<DeleteUserCommandHandler> _logger;
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository, ILogger<DeleteUserCommandHandler> logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _userRepository.GetByIdAsync(request.Id);

        if (userToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(AppUser), request.Id);
            throw new NotFoundException(nameof(AppUser), request.Id);
        }

        await _userRepository.DeleteAsync(userToDelete);

        _logger.LogInformation("User was deleted successfully!");
        return Unit.Value;
    }
}