using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Entities.Address DeliveryAddress { get; set; }
        public List<Entities.Order> Orders { get; set; }
        public List<Entities.Review> Reviews { get; set; }
    }
}
