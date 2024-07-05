using MediatR;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.Features.ProductReview.Queries.GetAllProductReviews;

public record GetAllProductReviewsQuery : IRequest<List<ProductReviewDto>>;