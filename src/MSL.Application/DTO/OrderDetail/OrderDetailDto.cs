namespace MLS.Application.DTO.OrderDetail
{
    public class OrderDetailDto
    {
        public int OrderDetailId { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; } // Order ID (for foreign key reference)
    }
}