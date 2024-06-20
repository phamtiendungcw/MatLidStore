using MLS.Application.DTO.OrderDetail;
using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductImage;
using MLS.Application.DTO.ProductOption;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.DTO.Product
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public List<UpdateProductOptionDto> ProductOptions { get; set; }
        public List<UpdateProductColorDto> ProductColors { get; set; }
        public List<UpdateProductImageDto> ProductImages { get; set; }
        public List<UpdateProductReviewDto> ProductReviews { get; set; }
        public List<UpdateOrderDetailDto> OrderDetails { get; set; }
    }
}