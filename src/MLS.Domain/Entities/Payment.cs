using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string PaymentMethod { get; set; } // Payment method (e.g., "Credit Card", "PayPal")
        public decimal AmountPaid { get; set; } // Amount paid
        public DateTime PaymentDate { get; set; } // Date and time payment was made

        public int OrderId { get; set; } // Foreign key referencing Order
        public Order Order { get; set; } // Navigation property for Order
    }
}