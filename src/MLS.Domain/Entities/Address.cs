using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;

        public int UserId { get; set; } // Foreign key referencing User
        public User User { get; set; } = null!; // Navigation property for User
    }
}