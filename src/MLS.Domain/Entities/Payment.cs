using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public int PaymentId { get; set; }
        public Entities.Order Order { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public Entities.PaymentMethod PaymentMethod { get; set; }
    }
}
