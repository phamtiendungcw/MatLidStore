using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public int InvoiceId { get; set; }
        public Entities.Order Order { get; set; }
        public DateTime IssueDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
