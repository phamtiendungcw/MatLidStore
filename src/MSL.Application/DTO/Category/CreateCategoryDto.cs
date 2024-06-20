using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Category
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CreateProductDto> Products { get; set; }
    }
}