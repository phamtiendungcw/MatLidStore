namespace MLS.Application.DTO.Wishlist
{
    public class WishlistDto
    {
        public int WishListId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; } // User ID (for foreign key reference)
    }
}