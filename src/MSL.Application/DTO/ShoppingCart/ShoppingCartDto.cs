using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.DTO.User;

namespace MLS.Application.DTO.ShoppingCart
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
        public List<ShoppingCartItemDto> ShoppingCartItems { get; set; }
    }
}