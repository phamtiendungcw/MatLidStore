using MLS.Application.DTO.Product;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.ProductReview;

public class ProductReviewDetailsDto : ProductReviewDto
{
    public ProductDto Product { get; set; } = new();
    public UserDto User { get; set; } = new();
}