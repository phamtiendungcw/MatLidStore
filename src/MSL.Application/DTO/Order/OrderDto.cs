namespace MLS.Application.DTO.Order
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; }
        public int UserId { get; set; } // User ID (for foreign key reference)
    }
}