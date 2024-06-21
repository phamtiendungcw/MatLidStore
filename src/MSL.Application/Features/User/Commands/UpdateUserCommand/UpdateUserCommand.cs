using MediatR;
using MLS.Application.DTO.User;

namespace MLS.Application.Features.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public UpdateUserDto? User { get; set; }
    }
}