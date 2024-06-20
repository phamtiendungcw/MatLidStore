using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductTag : BaseEntity
    {
        public string TagName { get; set; } = string.Empty; // Tag name (e.g., "Electronics", "Clothing")

        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } = null!; // Navigation property for Product

        public int TagId { get; set; } // Foreign key referencing Tag
        public Tag Tag { get; set; } = null!; // Navigation property for Tag
    }
}