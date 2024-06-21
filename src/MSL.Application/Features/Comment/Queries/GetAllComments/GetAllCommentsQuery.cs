using MediatR;
using MLS.Application.DTO.Comment;

namespace MLS.Application.Features.Comment.Queries.GetAllComments
{
    public record GetAllCommentsQuery : IRequest<List<CommentDto>>;
}