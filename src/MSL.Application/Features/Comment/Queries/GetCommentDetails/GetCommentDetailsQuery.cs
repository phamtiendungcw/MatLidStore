using MediatR;
using MLS.Application.DTO.Comment;

namespace MLS.Application.Features.Comment.Queries.GetCommentDetails;

public record GetCommentDetailsQuery(int Id) : IRequest<CommentDetailsDto>;