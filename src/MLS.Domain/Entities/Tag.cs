using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; } // Tag name (e.g., "Electronics", "Clothing")

        public ICollection<ProductTag> ProductTags { get; set; } // One-to-Many relationship with ProductTag
        public ICollection<Article> Articles { get; set; } // One-to-Many relationship with Article (optional)
    }
}