using MLS.Application.DTO.User;

namespace MLS.Application.DTO.ShoppingCart
{
    public class ShoppingCartDetailsDto : ShoppingCartDto
    {
        public UserDto User { get; set; } = new();
    }
}