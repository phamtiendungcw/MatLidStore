using MLS.Application.DTO.OrderDetail;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Order
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
}