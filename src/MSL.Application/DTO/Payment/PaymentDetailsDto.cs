using MLS.Application.DTO.Order;

namespace MLS.Application.DTO.Payment
{
    public class PaymentDetailsDto : PaymentDto
    {
        public OrderDto Order { get; set; } = new();
    }
}