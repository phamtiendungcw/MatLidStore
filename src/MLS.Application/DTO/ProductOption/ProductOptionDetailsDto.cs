using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.ProductOption;

public class ProductOptionDetailsDto : ProductOptionDto
{
    public ProductDto Product { get; set; } = new();
}