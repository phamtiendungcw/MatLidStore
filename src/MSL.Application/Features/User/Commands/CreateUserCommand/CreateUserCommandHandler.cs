using AutoMapper;
using FluentValidation;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.User);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid User", validationResult);

            var userToCreate = _mapper.Map<Domain.Entities.User>(request.User);
            await _userRepository.CreateAsync(userToCreate);

            return userToCreate.Id;
        }
    }
}