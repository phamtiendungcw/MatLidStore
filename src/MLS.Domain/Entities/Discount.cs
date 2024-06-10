using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Discount : BaseEntity
    {
        public string DiscountCode { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}