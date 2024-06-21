using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public string PaymentMethod { get; set; } = string.Empty; // Payment method (e.g., "Credit Card", "PayPal")
        [Column(TypeName = "decimal(18,4)")] public decimal AmountPaid { get; set; } // Amount paid
        public DateTime PaymentDate { get; set; } // Date and time payment was made

        public int OrderId { get; set; } // Foreign key referencing Order
        public Order Order { get; set; } = null!; // Navigation property for Order
    }
}