namespace MLS.Application.DTO.ShoppingCart
{
    public class ShoppingCartDto
    {
        public int ShoppingCartId { get; set; }
        public int UserId { get; set; } // User ID (for foreign key reference)
    }
}