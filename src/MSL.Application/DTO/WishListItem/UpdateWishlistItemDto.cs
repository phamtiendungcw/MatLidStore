namespace MLS.Application.DTO.WishListItem
{
    public class UpdateWishListItemDto
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? WishListId { get; set; }
    }
}