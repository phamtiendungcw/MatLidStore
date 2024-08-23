using System.ComponentModel.DataAnnotations;
using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class ProductReview : BaseEntity
{
    public int Rating { get; set; } // Rating out of 5 stars
    [MaxLength(500)] public string ReviewText { get; set; } = string.Empty; // Detailed review text
    public DateTime ReviewDate { get; set; } // Date and time review was posted

    public int ProductId { get; set; } // Foreign key referencing Product
    public Product Product { get; set; } = null!; // Navigation property for Product

    public int UserId { get; set; } // Foreign key referencing AppUser
    public AppUser AppUser { get; set; } = null!; // Navigation property for AppUser
}