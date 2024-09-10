using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Comment.Commands.UpdateCommentCommand;

public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IAppLogger<UpdateCommentCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository, IAppLogger<UpdateCommentCommandHandler> logger)
    {
        _mapper = mapper;
        _commentRepository = commentRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Comment, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update for {0} - {1}.", nameof(Comment), request.Comment);
            throw new BadRequestException("Invalid comment!", validationResult);
        }

        var commentToUpdate = _mapper.Map<Domain.Entities.Comment>(request.Comment);
        await _commentRepository.UpdateAsync(commentToUpdate);

        _logger.LogInformation("Comment was updated successfully!");
        return Unit.Value;
    }
}