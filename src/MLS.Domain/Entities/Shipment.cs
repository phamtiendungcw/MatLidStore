using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Shipment : BaseEntity
    {
        public string ShippingMethod { get; set; } // Shipping method (e.g., "UPS Ground", "FedEx Express")
        public string TrackingNumber { get; set; } // Tracking number for the shipment
        public DateTime EstimatedDeliveryDate { get; set; } // Estimated delivery date

        public int OrderId { get; set; } // Foreign key referencing Order
        public Order Order { get; set; } // Navigation property for Order
    }
}