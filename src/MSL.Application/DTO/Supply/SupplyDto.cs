namespace MLS.Application.DTO.Supply
{
    public class SupplyDto
    {
        public int SupplyId { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
        public int SupplierId { get; set; } // Supplier ID (for foreign key reference)
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}