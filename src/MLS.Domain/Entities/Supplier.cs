using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } // Supplier name
        public string ContactInformation { get; set; } // Contact details (email, phone)

        public ICollection<Product> Products { get; set; } // One-to-Many relationship with Product
    }
}