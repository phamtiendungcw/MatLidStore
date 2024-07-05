using MediatR;
using MLS.Application.DTO.Comment;

namespace MLS.Application.Features.Comment.Queries.GetCommentsByArticleId
{
    public record GetCommentsByArticleIdQuery(int articleId) : IRequest<List<CommentDto>>;
}