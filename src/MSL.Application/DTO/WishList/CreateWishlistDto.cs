using MLS.Application.DTO.WishListItem;

namespace MLS.Application.DTO.WishList
{
    public class CreateWishListDto
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<CreateWishListItemDto> WishListItems { get; set; }
    }
}