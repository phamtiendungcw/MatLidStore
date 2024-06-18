using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Commands.DeleteProductReviewCommand
{
    public class DeleteProductReviewCommandHandler : IRequestHandler<DeleteProductReviewCommand, Unit>
    {
        private readonly IProductReviewRepository _productReviewRepository;

        public DeleteProductReviewCommandHandler(IProductReviewRepository productReviewRepository)
        {
            _productReviewRepository = productReviewRepository;
        }

        public async Task<Unit> Handle(DeleteProductReviewCommand request, CancellationToken cancellationToken)
        {
            var productReviewToDelete = await _productReviewRepository.GetByIdAsync(request.Id);

            if (productReviewToDelete is null)
                throw new NotFoundException(nameof(Domain.Entities.ProductReview), request.Id);

            await _productReviewRepository.DeleteAsync(productReviewToDelete);

            return Unit.Value;
        }
    }
}