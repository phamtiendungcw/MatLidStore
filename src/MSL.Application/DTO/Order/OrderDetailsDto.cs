using MLS.Application.DTO.OrderDetail;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.Order
{
    public class OrderDetailsDto : OrderDto
    {
        public UserDto User { get; set; } = new();
        public List<OrderDetailDto> OrderDetails { get; set; } = new();
    }
}