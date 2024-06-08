using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Category
{
    public class CategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        // Các thuộc tính khác

        public virtual ICollection<ProductDto> Products { get; set; }
    }
}