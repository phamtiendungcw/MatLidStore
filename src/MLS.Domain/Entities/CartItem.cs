using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Entities.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
