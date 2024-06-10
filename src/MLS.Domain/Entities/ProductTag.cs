using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductTag : BaseEntity
    {
        public Product Product { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}