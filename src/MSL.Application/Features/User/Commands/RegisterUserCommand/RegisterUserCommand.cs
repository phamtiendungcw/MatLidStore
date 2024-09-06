using MediatR;
using MLS.Application.DTO.User;
using MLS.Application.Models.Identity;

namespace MLS.Application.Features.User.Commands.RegisterUserCommand;

public class RegisterUserCommand : IRequest<RegistrationResponse>
{
    public RegisterModel RegisterUser { get; set; } = new();
}