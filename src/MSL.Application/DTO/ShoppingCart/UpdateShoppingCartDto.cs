using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.DTO.ShoppingCart
{
    public class UpdateShoppingCartDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<UpdateShoppingCartItemDto> ShoppingCartItems { get; set; }
    }
}