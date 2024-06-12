using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.DTO.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}