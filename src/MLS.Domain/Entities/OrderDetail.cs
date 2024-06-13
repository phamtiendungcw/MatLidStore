using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class OrderDetail : BaseEntity
    {
        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } // Navigation property for Product

        public int Quantity { get; set; } // Quantity of the product ordered
        public decimal Price { get; set; } // Price of the product at the time of order

        public int OrderId { get; set; } // Foreign key referencing Order
        public Order Order { get; set; } // Navigation property for Order
    }
}