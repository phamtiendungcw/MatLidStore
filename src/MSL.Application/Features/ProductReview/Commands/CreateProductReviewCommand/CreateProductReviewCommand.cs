using MediatR;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.Features.ProductReview.Commands.CreateProductReviewCommand
{
    public abstract class CreateProductReviewCommand : IRequest<int>
    {
        public CreateProductReviewDto ProductReview { get; set; } = new();
    }
}