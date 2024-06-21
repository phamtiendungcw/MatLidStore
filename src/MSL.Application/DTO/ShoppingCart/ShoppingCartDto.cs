using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.DTO.ShoppingCart
{
    public class ShoppingCartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<ShoppingCartItemDto> ShoppingCartItems { get; set; } = new();
    }
}