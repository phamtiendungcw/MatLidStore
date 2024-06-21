using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImageUrl { get; set; } = string.Empty; // URL of the product image
        public string? ImageDescription { get; set; } // Optional image description

        public int ProductId { get; set; } // Foreign key referencing Product
        public Product Product { get; set; } = null!; // Navigation property for Product
    }
}