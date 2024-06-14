using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductOption : BaseEntity
    {
        public string Name { get; set; } // Option name (e.g., "Size", "Color")
        public decimal Value { get; set; }

        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } // Navigation property for Product
    }
}