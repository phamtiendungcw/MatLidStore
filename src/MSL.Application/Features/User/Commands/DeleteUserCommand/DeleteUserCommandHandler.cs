using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.DeleteUserCommand;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var userToDelete = await _userRepository.GetByIdAsync(request.Id);

        if (userToDelete is null)
            throw new NotFoundException(nameof(AppUser), request.Id);

        await _userRepository.DeleteAsync(userToDelete);

        return Unit.Value;
    }
}