using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class ProductColor : BaseEntity
{
    [MaxLength(50)] public string ColorName { get; set; } = string.Empty; // Color name (e.g., "Red", "Blue")
    [MaxLength(50)] public string ColorHexCode { get; set; } = string.Empty; // Hexadecimal color code (#FF0000, #0000FF)

    public int ProductId { get; set; } // Foreign key referencing Product
    public Product Product { get; set; } = null!; // Navigation property for Product
}