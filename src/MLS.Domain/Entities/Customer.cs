using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Address? DeliveryAddress { get; set; }
        public List<Order>? Orders { get; set; }
        public List<Review>? Reviews { get; set; }
    }
}