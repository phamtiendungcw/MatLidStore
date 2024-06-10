using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}