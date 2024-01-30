using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Delivery : BaseEntity
    {
        public Entities.Order? Order { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Entities.Address? DeliveryAddress { get; set; }
    }
}
