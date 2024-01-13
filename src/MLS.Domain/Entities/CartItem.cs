using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public int CartItemId { get; set; }
        public Entities.Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
