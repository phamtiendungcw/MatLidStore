namespace MLS.Application.DTO.WishlistItem
{
    public class WishlistItemDto
    {
        public int WishListItemId { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
        public int WishListId { get; set; } // Wish List ID (for foreign key reference)
    }
}