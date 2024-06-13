using MLS.Application.DTO.Product;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.DTO.ShoppingCartItem
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCartDto ShoppingCart { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public int Quantity { get; set; }
    }
}