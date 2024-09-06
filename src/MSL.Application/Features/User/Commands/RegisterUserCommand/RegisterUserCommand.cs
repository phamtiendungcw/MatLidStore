using MediatR;
using MLS.Application.Models.Identity;

namespace MLS.Application.Features.User.Commands.RegisterUserCommand;

public class RegisterUserCommand : IRequest<RegistrationResponse>
{
    public RegistrationRequest RegistrationUser { get; set; } = new();
}