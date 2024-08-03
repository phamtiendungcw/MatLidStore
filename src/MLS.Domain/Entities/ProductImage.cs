using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class ProductImage : BaseEntity
{
    [MaxLength(200)] public string ImageUrl { get; set; } = string.Empty; // URL of the product image
    [MaxLength(300)] public string ImageDescription { get; set; } = string.Empty; // Optional image description

    public int ProductId { get; set; } // Foreign key referencing Product
    public Product Product { get; set; } = null!; // Navigation property for Product
}