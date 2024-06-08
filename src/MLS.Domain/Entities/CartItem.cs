using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class CartItem : BaseEntity
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }
}