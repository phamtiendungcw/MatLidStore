using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Review : BaseEntity
    {
        public int ReviewId { get; set; }
        public string Comment { get; set; }
        public DateTime Date { get; set; }
        public Entities.Customer Customer { get; set; }
    }
}
