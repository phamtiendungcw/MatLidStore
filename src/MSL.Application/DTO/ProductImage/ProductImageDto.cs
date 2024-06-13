using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.ProductImage
{
    public class ProductImageDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}