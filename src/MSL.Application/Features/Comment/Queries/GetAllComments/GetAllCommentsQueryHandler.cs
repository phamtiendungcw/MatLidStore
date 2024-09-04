using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;

namespace MLS.Application.Features.Comment.Queries.GetAllComments;

public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, List<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IAppLogger<GetAllCommentsQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetAllCommentsQueryHandler(IMapper mapper, ICommentRepository commentRepository, IAppLogger<GetAllCommentsQueryHandler> logger)
    {
        _mapper = mapper;
        _commentRepository = commentRepository;
        _logger = logger;
    }

    public async Task<List<CommentDto>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetAllAsync();
        var data = _mapper.Map<List<CommentDto>>(comments);

        _logger.LogInformation("Comments were retrieved successfully!");
        return data;
    }
}