using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class WishList : BaseEntity
    {
        public int WishListId { get; set; }
        public Entities.Customer Customer { get; set; }
        public Entities.Address ShippingAddress { get; set; }
        public List<Entities.Product> Products { get; set; }
    }
}
