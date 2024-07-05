using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Comment.Queries.GetCommentsByArticleId;

public class GetCommentsByArticleIdQueryHandler : IRequestHandler<GetCommentsByArticleIdQuery, List<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public GetCommentsByArticleIdQueryHandler(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

    public async Task<List<CommentDto>> Handle(GetCommentsByArticleIdQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetCommentsByArticleIdAsync(request.articleId);

        if (comments is null)
            throw new NotFoundException(nameof(Domain.Entities.Comment), request.articleId);

        var data = _mapper.Map<List<CommentDto>>(comments);

        return data;
    }
}