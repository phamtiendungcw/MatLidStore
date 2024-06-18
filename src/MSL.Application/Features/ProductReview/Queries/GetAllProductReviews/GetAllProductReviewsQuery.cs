using MediatR;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.Features.ProductReview.Queries.GetAllProductReviews
{
    public abstract record GetAllProductReviewsQuery : IRequest<List<ProductReviewDto>>;
}