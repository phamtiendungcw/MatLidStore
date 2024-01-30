using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Delivery : BaseEntity
    {
        public Order? Order { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Address? DeliveryAddress { get; set; }
    }
}
