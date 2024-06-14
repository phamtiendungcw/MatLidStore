using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } // Navigation property for User
    }
}