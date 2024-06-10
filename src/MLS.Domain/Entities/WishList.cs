namespace MLS.Domain.Entities
{
    public class Wishlist
    {
        public int WishlistId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<WishlistItem> WishlistItems { get; set; }
    }
}