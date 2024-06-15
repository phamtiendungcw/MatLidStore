namespace MLS.Application.DTO.ShoppingCartItem
{
    public class CreateShoppingCartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int ShoppingCartId { get; set; }
    }
}