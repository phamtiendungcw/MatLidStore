using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string Name { get; set; } // Discount name
        public decimal DiscountPercentage { get; set; } // Percentage discount off the price
        public DateTime StartDate { get; set; } // Start date of the discount
        public DateTime EndDate { get; set; } // End date of the discount
    }
}