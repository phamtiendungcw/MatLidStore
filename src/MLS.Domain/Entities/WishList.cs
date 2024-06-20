using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class WishList : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // Wish list name (optional)

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } = null!; // Navigation property for User

        public List<WishListItem> WishListItems { get; set; } = new List<WishListItem>(); // One-to-Many relationship with WishListItem
    }
}