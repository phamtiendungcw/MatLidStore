using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Domain.Entities;

public class Product : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty; // Product name
    [MaxLength(50)] public string Description { get; set; } = string.Empty; // Product description
    [Column(TypeName = "decimal(18,4)")] public decimal Price { get; set; } // Product price
    public int StockQuantity { get; set; }
    [MaxLength(50)] public string Sku { get; set; } = string.Empty;

    public int CategoryId { get; set; } // Foreign key referencing Category
    public Category Category { get; set; } = null!; // Navigation property for Category

    public List<ProductOption> ProductOptions { get; set; } = new(); // One-to-Many relationship with ProductOption
    public List<ProductColor> ProductColors { get; set; } = new(); // One-to-Many relationship with ProductColor
    public List<ProductImage> ProductImages { get; set; } = new(); // One-to-Many relationship with ProductImage
    public List<ProductReview> ProductReviews { get; set; } = new(); // One-to-Many relationship with ProductReview
    public List<OrderDetail> OrderDetails { get; set; } = new(); // One-to-Many relationship with OrderDetail
}