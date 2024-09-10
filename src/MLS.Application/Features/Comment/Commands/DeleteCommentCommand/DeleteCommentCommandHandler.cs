using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Comment.Commands.DeleteCommentCommand;

public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommand, Unit>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IAppLogger<DeleteCommentCommandHandler> _logger;

    public DeleteCommentCommandHandler(ICommentRepository commentRepository, IAppLogger<DeleteCommentCommandHandler> logger)
    {
        _commentRepository = commentRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
    {
        var commentToDelete = await _commentRepository.GetByIdAsync(request.Id);

        if (commentToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(Comment), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Comment), request.Id);
        }

        await _commentRepository.DeleteAsync(commentToDelete);

        _logger.LogInformation("Comment was deleted successfully!");
        return Unit.Value;
    }
}