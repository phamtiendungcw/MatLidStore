using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty; // Category name
        public string Description { get; set; } = string.Empty; // Optional category description

        public ICollection<Product> Products { get; set; } = new List<Product>(); // One-to-Many relationship with Product
    }
}