using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class Category : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; } = string.Empty; // Category name
    [MaxLength(200)] public string Description { get; set; } = string.Empty; // Optional category description

    public ICollection<Product> Products { get; set; } = new List<Product>(); // One-to-Many relationship with Product
}