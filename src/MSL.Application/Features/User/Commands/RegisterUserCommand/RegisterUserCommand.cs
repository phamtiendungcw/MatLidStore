using MediatR;
using MLS.Application.DTO.User;

namespace MLS.Application.Features.User.Commands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest<int>
    {
        public RegisterModel RegisterUser { get; set; } = new();
    }
}