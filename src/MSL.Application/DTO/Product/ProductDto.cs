using MLS.Application.DTO.Category;
using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductImage;
using MLS.Application.DTO.ProductOption;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<ProductImageDto> ProductImages { get; set; }
        public ICollection<ProductOptionDto> ProductOptions { get; set; }
        public ICollection<ProductColorDto> ProductColors { get; set; }
        public ICollection<ProductReviewDto> ProductReviews { get; set; }
    }
}