using MLS.Application.DTO.WishListItem;

namespace MLS.Application.DTO.WishList
{
    public class UpdateWishListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public List<UpdateWishListItemDto> WishListItems { get; set; }
    }
}