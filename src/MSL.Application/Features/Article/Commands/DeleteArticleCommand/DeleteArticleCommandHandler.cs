using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Commands.DeleteArticleCommand;

public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Unit>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IAppLogger<DeleteArticleCommandHandler> _logger;

    public DeleteArticleCommandHandler(IArticleRepository articleRepository, IAppLogger<DeleteArticleCommandHandler> logger)
    {
        _articleRepository = articleRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var articleToDelete = await _articleRepository.GetByIdAsync(request.Id);

        if (articleToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(Domain.Entities.Article), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Article), request.Id);
        }

        await _articleRepository.DeleteAsync(articleToDelete);

        _logger.LogInformation("Article was deleted successfully!");
        return Unit.Value;
    }
}