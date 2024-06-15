using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } // Supplier name
        public string ContactEmail { get; set; } // Contact details email
        public string ContactPhone { get; set; } // Contact details phone

        public List<Product> Products { get; set; } // One-to-Many relationship with Product
    }
}