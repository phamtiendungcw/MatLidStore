using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Product.Commands.DeleteProductCommand;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IAppLogger<DeleteProductCommandHandler> _logger;
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository, IAppLogger<DeleteProductCommandHandler> logger)
    {
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        // Convert to domain entity obj
        var productToDelete = await _productRepository.GetByIdAsync(request.Id);

        // Verify that record exists
        if (productToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(Product), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);
        }

        // Remove in database
        await _productRepository.DeleteAsync(productToDelete);

        // Return Unit value
        _logger.LogInformation("Product was deleted successfully!");
        return Unit.Value;
    }
}