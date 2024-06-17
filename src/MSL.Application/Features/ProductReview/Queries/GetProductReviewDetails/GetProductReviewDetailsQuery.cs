using MediatR;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.Features.ProductReview.Queries.GetProductReviewDetails
{
    public abstract record GetProductReviewDetailsQuery(int Id) : IRequest<ProductReviewDetailsDto>;
}