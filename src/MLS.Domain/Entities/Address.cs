using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string StreetAddress { get; set; } // Street address
        public string City { get; set; } // City
        public string State { get; set; } // State/Province
        public string ZipCode { get; set; } // Postal code
        public string Country { get; set; } // Country

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } // Navigation property for User
    }
}