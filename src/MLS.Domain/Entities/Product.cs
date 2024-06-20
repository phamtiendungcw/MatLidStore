using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // Product name
        public string Description { get; set; } = string.Empty; // Product description
        public decimal Price { get; set; } // Product price

        public int CategoryId { get; set; } // Foreign key referencing Category
        public Category Category { get; set; } = null!; // Navigation property for Category

        public List<ProductOption> ProductOptions { get; set; } = new(); // One-to-Many relationship with ProductOption
        public List<ProductColor> ProductColors { get; set; } = new(); // One-to-Many relationship with ProductColor
        public List<ProductImage> ProductImages { get; set; } = new(); // One-to-Many relationship with ProductImage
        public List<ProductReview> ProductReviews { get; set; } = new(); // One-to-Many relationship with ProductReview
        public List<OrderDetail> OrderDetails { get; set; } = new(); // One-to-Many relationship with OrderDetail
    }
}