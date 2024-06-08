using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public Order? Order { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
    }
}