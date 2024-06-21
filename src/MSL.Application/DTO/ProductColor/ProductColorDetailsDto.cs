using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.ProductColor
{
    public class ProductColorDetailsDto : ProductColorDto
    {
        public ProductDto Product { get; set; } = new();
    }
}