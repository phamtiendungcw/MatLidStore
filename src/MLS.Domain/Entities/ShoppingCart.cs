using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } = null!; // Navigation property for User

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new(); // One-to-Many relationship with ShoppingCartItem
    }
}