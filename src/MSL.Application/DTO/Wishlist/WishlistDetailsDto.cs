using MLS.Application.DTO.User;
using MLS.Application.DTO.WishListItem;

namespace MLS.Application.DTO.WishList
{
    public class WishListDetailsDto : WishListDto
    {
        public UserDto User { get; set; } = new();
        public List<WishListItemDto> WishListItems { get; set; } = new();
    }
}