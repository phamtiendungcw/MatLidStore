using MediatR;
using MLS.Application.DTO.User;

namespace MLS.Application.Features.User.Commands.CreateUserCommand
{
    public abstract class CreateUserCommand : IRequest<int>
    {
        public UserDto User { get; set; }
    }
}