using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.ProductOption
{
    public class ProductOptionDto
    {
        public int Id { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}