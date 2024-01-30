using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class WishList : BaseEntity
    {
        public Entities.Customer? Customer { get; set; }
        public List<Entities.Product>? Products { get; set; }
    }
}
