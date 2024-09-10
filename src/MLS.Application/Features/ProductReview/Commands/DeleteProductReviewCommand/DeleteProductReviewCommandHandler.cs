using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Commands.DeleteProductReviewCommand;

public class DeleteProductReviewCommandHandler : IRequestHandler<DeleteProductReviewCommand, Unit>
{
    private readonly IAppLogger<DeleteProductReviewCommandHandler> _logger;
    private readonly IProductReviewRepository _productReviewRepository;

    public DeleteProductReviewCommandHandler(IProductReviewRepository productReviewRepository, IAppLogger<DeleteProductReviewCommandHandler> logger)
    {
        _productReviewRepository = productReviewRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteProductReviewCommand request, CancellationToken cancellationToken)
    {
        var productReviewToDelete = await _productReviewRepository.GetByIdAsync(request.Id);

        if (productReviewToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(ProductReview), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.ProductReview), request.Id);
        }

        await _productReviewRepository.DeleteAsync(productReviewToDelete);

        _logger.LogInformation("Product review was deleted successfully!");
        return Unit.Value;
    }
}