using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Wishlist : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}