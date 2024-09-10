using MLS.Application.DTO.Category;
using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductImage;
using MLS.Application.DTO.ProductOption;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.DTO.Product;

public class ProductDetailsDto : ProductDto
{
    public CategoryDto Category { get; set; } = new();
    public List<ProductOptionDto> ProductOptions { get; set; } = new();
    public List<ProductColorDto> ProductColors { get; set; } = new();
    public List<ProductImageDto> ProductImages { get; set; } = new();
    public List<ProductReviewDto> ProductReviews { get; set; } = new();
}