using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.UpdateUserCommand;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.User, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid AppUser", validationResult);

        var userToUpdate = _mapper.Map<AppUser>(request.User);
        await _userRepository.UpdateAsync(userToUpdate);

        return Unit.Value;
    }
}