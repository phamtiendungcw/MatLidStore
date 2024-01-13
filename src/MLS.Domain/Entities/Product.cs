using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Product : BaseEntity
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Entities.Category Category { get; set; }
        public Entities.Supplier Supplier { get; set; }
        public List<Entities.ProductImage> Images { get; set; }
        public List<Entities.Review> Reviews { get; set; }
    }
}
