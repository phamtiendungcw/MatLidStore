using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Promotion : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}