using MLS.Application.DTO.Product;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.ProductReview
{
    public class ProductReviewDto
    {
        public int Id { get; set; }
        public string ReviewContent { get; set; }
        public int Rating { get; set; }
        public DateTime ReviewDate { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}