using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Supply : BaseEntity
    {
        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } // Navigation property for Product

        public int SupplierId { get; set; } // Foreign key referencing Supplier
        public Supplier Supplier { get; set; } // Navigation property for Supplier

        public int Quantity { get; set; } // Quantity of the product supplied by the supplier
        public decimal Price { get; set; } // Cost of the product from the supplier
    }
}