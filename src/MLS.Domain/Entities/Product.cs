using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public Category? Category { get; set; }
        public Supplier? Supplier { get; set; }
        public List<ProductImage>? Images { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}