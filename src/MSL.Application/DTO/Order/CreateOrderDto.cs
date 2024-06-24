using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.DTO.Order
{
    public class CreateOrderDto
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalPrice { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public int UserId { get; set; }
        public List<CreateOrderDetailDto> OrderDetails { get; set; } = new();
    }
}