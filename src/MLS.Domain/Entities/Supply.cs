using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Domain.Entities
{
    public class Supply : BaseEntity
    {
        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } = null!; // Navigation property for Product

        public int SupplierId { get; set; } // Foreign key referencing Supplier
        public Supplier Supplier { get; set; } = null!; // Navigation property for Supplier

        public int Quantity { get; set; } // Quantity of the product supplied by the supplier
        [Column(TypeName = "decimal(18,4)")] public decimal Price { get; set; } // Cost of the product from the supplier
    }
}