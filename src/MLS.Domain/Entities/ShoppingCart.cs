using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}