using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } // Product name
        public string Description { get; set; } // Product description
        public decimal Price { get; set; } // Product price

        public int CategoryId { get; set; } // Foreign key referencing Category
        public Category Category { get; set; } // Navigation property for Category

        public ICollection<ProductOption> ProductOptions { get; set; } // One-to-Many relationship with ProductOption
        public ICollection<ProductColor> ProductColors { get; set; } // One-to-Many relationship with ProductColor
        public ICollection<ProductImage> ProductImages { get; set; } // One-to-Many relationship with ProductImage
        public ICollection<ProductReview> ProductReviews { get; set; } // One-to-Many relationship with ProductReview
        public ICollection<OrderDetail> OrderDetails { get; set; } // One-to-Many relationship with OrderDetail
    }
}