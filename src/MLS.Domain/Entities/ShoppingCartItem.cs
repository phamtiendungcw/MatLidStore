using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } // Navigation property for Product

        public int Quantity { get; set; } // Quantity of the product in the cart
        public decimal Price { get; set; } // Price of the product at the time it was added to the cart

        public int ShoppingCartId { get; set; } // Foreign key referencing ShoppingCart
        public ShoppingCart ShoppingCart { get; set; } // Navigation property for ShoppingCart
    }
}