using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class WishList : BaseEntity
    {
        public Customer? Customer { get; set; }
        public List<Product>? Products { get; set; }
    }
}
