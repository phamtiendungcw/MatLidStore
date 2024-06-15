using MLS.Application.DTO.User;
using MLS.Application.DTO.WishListItem;

namespace MLS.Application.DTO.WishList
{
    public class WishListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public List<WishListItemDto> WishListItems { get; set; }
    }
}