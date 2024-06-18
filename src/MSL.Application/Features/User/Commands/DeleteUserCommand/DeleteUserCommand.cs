using MediatR;

namespace MLS.Application.Features.User.Commands.DeleteUserCommand
{
    public abstract class DeleteUserCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}