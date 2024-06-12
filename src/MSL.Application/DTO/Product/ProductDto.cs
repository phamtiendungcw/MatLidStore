using MLS.Application.DTO.ProductOption;

namespace MLS.Application.DTO.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductOptionDto> ProductOptions { get; set; } = new List<ProductOptionDto>();
        public List<string> Tags { get; set; } = new List<string>();
    }
}