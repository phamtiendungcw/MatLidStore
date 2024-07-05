using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.ProductImage;

public class ProductImageDetailsDto : ProductImageDto
{
    public ProductDto Product { get; set; } = new();
}