namespace MLS.Application.DTO.ShoppingCartItem
{
    public class ShoppingCartItemDto
    {
        public int ShoppingCartItemId { get; set; }
        public int ProductId { get; set; } // Product ID (for foreign key reference)
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ShoppingCartId { get; set; } // Shopping Cart ID (for foreign key reference)
    }
}