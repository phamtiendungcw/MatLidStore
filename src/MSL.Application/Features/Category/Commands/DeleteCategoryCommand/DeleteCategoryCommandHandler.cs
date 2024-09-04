using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Category.Commands.DeleteCategoryCommand;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAppLogger<DeleteCategoryCommandHandler> _logger;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IAppLogger<DeleteCategoryCommandHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id);

        if (categoryToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(Category), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);
        }

        await _categoryRepository.DeleteAsync(categoryToDelete);

        _logger.LogInformation("Category was deleted successfully!");
        return Unit.Value;
    }
}