namespace MLS.Application.DTO.ProductOption
{
    public class ProductOptionDto
    {
        public int ProductOptionId { get; set; }
        public string Name { get; set; }
        public decimal PriceAdjustment { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
    }
}