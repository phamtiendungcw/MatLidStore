using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Category.Commands.DeleteCategoryCommand
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryToDelete = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryToDelete is null)
                throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);

            await _categoryRepository.DeleteAsync(categoryToDelete);

            return Unit.Value;
        }
    }
}