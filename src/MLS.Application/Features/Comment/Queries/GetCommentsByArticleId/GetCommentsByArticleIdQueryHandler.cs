using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Comment.Queries.GetCommentsByArticleId;

public class GetCommentsByArticleIdQueryHandler : IRequestHandler<GetCommentsByArticleIdQuery, List<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IAppLogger<GetCommentsByArticleIdQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetCommentsByArticleIdQueryHandler(ICommentRepository commentRepository, IMapper mapper, IAppLogger<GetCommentsByArticleIdQueryHandler> logger)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<CommentDto>> Handle(GetCommentsByArticleIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetCommentsByArticleIdAsync(request.articleId);

        if (comments is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request by article id.", nameof(Comment), request.articleId);
            throw new NotFoundException(nameof(Domain.Entities.Comment), request.articleId);
        }

        var data = _mapper.Map<List<CommentDto>>(comments);

        _logger.LogInformation("Comment by article id is {0} was retrieved successfully!", request.articleId);
        return data;
    }
}