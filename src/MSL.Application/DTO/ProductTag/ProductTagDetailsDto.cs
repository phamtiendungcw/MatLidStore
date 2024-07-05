using MLS.Application.DTO.Product;
using MLS.Application.DTO.Tag;

namespace MLS.Application.DTO.ProductTag;

public class ProductTagDetailsDto : ProductTagDto
{
    public ProductDto Product { get; set; } = new();
    public TagDto Tag { get; set; } = new();
}