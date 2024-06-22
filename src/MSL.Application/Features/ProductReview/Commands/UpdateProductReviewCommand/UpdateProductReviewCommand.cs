using MediatR;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.Features.ProductReview.Commands.UpdateProductReviewCommand
{
    public class UpdateProductReviewCommand : IRequest<Unit>
    {
        public UpdateProductReviewDto ProductReview { get; set; } = null!;
    }
}