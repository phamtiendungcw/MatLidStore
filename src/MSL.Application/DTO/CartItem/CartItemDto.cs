using MLS.Application.DTO.Product;

namespace MLS.Application.DTO.CartItem
{
    public class CartItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        // Các thuộc tính khác

        public virtual ProductDto Product { get; set; }
    }
}