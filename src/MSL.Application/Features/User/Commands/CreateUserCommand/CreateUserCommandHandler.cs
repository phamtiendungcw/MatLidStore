using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;

namespace MLS.Application.Features.User.Commands.CreateUserCommand;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateUserDtoValidator();
        var validationResult = await validator.ValidateAsync(request.User, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid AppUser", validationResult);

        var userToCreate = _mapper.Map<AppUser>(request.User);
        await _userRepository.CreateAsync(userToCreate);

        return userToCreate.Id;
    }
}