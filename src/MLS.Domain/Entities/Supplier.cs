using System.ComponentModel.DataAnnotations;
using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class Supplier : BaseEntity
{
    [MaxLength(100)] public string Name { get; set; } = string.Empty; // Supplier name
    [EmailAddress] public string ContactEmail { get; set; } = string.Empty; // Contact details email
    [Phone] public string ContactPhone { get; set; } = string.Empty; // Contact details phone

    public List<Product> Products { get; set; } = new(); // One-to-Many relationship with Product
}