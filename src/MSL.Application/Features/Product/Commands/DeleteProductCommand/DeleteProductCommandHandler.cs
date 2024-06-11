using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            // Convert to domain entity obj
            var productToDelete = await _productRepository.GetByIdAsync(request.Id);

            // Verify that record exists

            // Remove in database
            await _productRepository.DeleteAsync(productToDelete);

            // Return Unit value
            return Unit.Value;
        }
    }
}