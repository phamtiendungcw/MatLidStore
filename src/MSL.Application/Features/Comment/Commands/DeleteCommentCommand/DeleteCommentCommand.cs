using MediatR;

namespace MLS.Application.Features.Comment.Commands.DeleteCommentCommand
{
    public abstract class DeleteCommentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}