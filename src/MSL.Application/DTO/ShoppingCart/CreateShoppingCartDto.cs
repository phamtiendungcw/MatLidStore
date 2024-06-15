using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.DTO.ShoppingCart
{
    public class CreateShoppingCartDto
    {
        public int UserId { get; set; }
        public List<CreateShoppingCartItemDto> ShoppingCartItems { get; set; }
    }
}