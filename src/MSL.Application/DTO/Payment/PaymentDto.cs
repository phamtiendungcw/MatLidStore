using MLS.Application.DTO.Order;

namespace MLS.Application.DTO.Payment
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}