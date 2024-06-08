namespace MLS.Application.DTO.CartItem
{
    public class CartItemDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}