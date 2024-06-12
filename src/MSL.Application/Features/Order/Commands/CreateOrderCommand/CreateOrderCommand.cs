using MediatR;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string ShippingAddress { get; set; } = String.Empty;
        public List<OrderDetailDto> OrderDetails { get; set; } = new();
    }
}