using MLS.Application.DTO.Product;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.DTO.ShoppingCartItem;

public class ShoppingCartItemDetailsDto : ShoppingCartItemDto
{
    public ProductDto Product { get; set; } = new();
    public ShoppingCartDto ShoppingCart { get; set; } = new();
}