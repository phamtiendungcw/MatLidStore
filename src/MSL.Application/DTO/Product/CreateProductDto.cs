using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductImage;
using MLS.Application.DTO.ProductOption;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.DTO.Product
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<CreateProductImageDto> ProductImages { get; set; }
        public List<CreateProductOptionDto> ProductOptions { get; set; }
        public List<CreateProductColorDto> ProductColors { get; set; }
        public List<CreateProductReviewDto> ProductReviews { get; set; }
        public List<int> ProductTagIds { get; set; }
    }
}