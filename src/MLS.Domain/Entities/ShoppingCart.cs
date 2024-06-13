using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } // Navigation property for User

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; } // One-to-Many relationship with ShoppingCartItem
    }
}