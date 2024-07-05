using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Category;

public class CategoryDetailsDto : CategoryDto
{
    public List<ProductDto> Products { get; set; } = new();
}