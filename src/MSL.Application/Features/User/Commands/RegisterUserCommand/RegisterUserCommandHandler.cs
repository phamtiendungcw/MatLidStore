using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.User.Commands.RegisterUserCommand
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new RegisterUserModelValidator();
            var validationResult = await validator.ValidateAsync(request.RegisterUser, cancellationToken);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid AppUser", validationResult);

            var userToCreate = _mapper.Map<Domain.Entities.AppUser>(request.RegisterUser);
            await _userRepository.CreateAsync(userToCreate);

            return userToCreate.Id;
        }
    }
}