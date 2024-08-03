using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class ProductOption : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty; // Option name (e.g., "Size", "Color")
    [MaxLength(50)] public string Value { get; set; } = string.Empty; // Option value (e.g., "25", "Black")

    public int ProductId { get; set; } // Foreign key referencing Product
    public Product Product { get; set; } = null!; // Navigation property for Product
}