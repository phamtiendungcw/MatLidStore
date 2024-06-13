using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } // Category name
        public string Description { get; set; } // Optional category description

        public ICollection<Product> Products { get; set; } // One-to-Many relationship with Product
    }
}