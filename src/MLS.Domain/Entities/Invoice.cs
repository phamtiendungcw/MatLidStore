using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public Order? Order { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}