using MLS.Domain.Common;

namespace MLS.Domain.Entities;

public class Supplier : BaseEntity
{
    public string Name { get; set; } = string.Empty; // Supplier name
    public string ContactEmail { get; set; } = string.Empty; // Contact details email
    public string ContactPhone { get; set; } = string.Empty; // Contact details phone

    public List<Product> Products { get; set; } = new(); // One-to-Many relationship with Product
}