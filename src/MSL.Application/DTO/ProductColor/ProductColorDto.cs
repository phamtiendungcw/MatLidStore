using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.ProductColor
{
    public class ProductColorDto
    {
        public int Id { get; set; }
        public string ColorName { get; set; }
        public string HexValue { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}