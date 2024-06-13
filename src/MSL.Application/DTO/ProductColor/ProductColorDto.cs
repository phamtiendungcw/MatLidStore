namespace MLS.Application.DTO.ProductColor
{
    public class ProductColorDto
    {
        public int ProductColorId { get; set; }
        public string ColorName { get; set; }
        public string ColorHexCode { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
    }
}