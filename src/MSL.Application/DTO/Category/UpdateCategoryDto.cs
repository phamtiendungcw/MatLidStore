using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.Category
{
    public class UpdateCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UpdateProductDto> Products { get; set; }
    }
}