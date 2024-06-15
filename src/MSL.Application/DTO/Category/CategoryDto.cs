using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ProductDto> Products { get; set; }
    }
}