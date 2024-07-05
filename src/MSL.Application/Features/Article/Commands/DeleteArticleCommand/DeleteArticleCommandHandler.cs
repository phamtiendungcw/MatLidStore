using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Commands.DeleteArticleCommand;

public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand, Unit>
{
    private readonly IArticleRepository _articleRepository;

    public DeleteArticleCommandHandler(IArticleRepository articleRepository)
    {
        _articleRepository = articleRepository;
    }

    public async Task<Unit> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
        var articleToDelete = await _articleRepository.GetByIdAsync(request.Id);

        if (articleToDelete is null)
            throw new NotFoundException(nameof(Domain.Entities.Article), request.Id);

        await _articleRepository.DeleteAsync(articleToDelete);

        return Unit.Value;
    }
}