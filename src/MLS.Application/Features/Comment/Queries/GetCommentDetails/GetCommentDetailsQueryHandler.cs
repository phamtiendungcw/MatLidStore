using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Comment.Queries.GetCommentDetails;

public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, CommentDetailsDto>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IAppLogger<GetCommentDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetCommentDetailsQueryHandler(IMapper mapper, ICommentRepository commentRepository, IAppLogger<GetCommentDetailsQueryHandler> logger)
    {
        _mapper = mapper;
        _commentRepository = commentRepository;
        _logger = logger;
    }

    public async Task<CommentDetailsDto> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetByIdAsync(request.Id);

        if (comment is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Comment), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Comment), request.Id);
        }

        var data = _mapper.Map<CommentDetailsDto>(comment);

        _logger.LogInformation("Comment details were retrieved successfully!");
        return data;
    }
}