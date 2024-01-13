using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Promotion : BaseEntity
    {
        public int PromotionId { get; set; }
        public string Code { get; set; }
        public decimal Discount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
