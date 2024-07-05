using System.ComponentModel.DataAnnotations.Schema;
using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class ProductOption : BaseEntity
{
    public string Name { get; set; } = string.Empty; // Option name (e.g., "Size", "Color")
    [Column(TypeName = "decimal(18,4)")] public decimal Value { get; set; } // Option value (e.g., "25", "Black")

    public int ProductId { get; set; } // Foreign key referencing Product
    public Product Product { get; set; } = null!; // Navigation property for Product
}