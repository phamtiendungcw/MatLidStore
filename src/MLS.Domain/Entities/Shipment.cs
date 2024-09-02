using MLS.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace MLS.Domain.Entities;

public class Shipment : BaseEntity
{
    [MaxLength(50)] public string ShippingMethod { get; set; } = string.Empty; // Shipping method (e.g., "UPS Ground", "FedEx Express")

    [MaxLength(50)] public string TrackingNumber { get; set; } = string.Empty; // Tracking number for the shipment
    public DateTime EstimatedDeliveryDate { get; set; } // Estimated delivery date

    public int OrderId { get; set; } // Foreign key referencing Order
    public Order Order { get; set; } = null!; // Navigation property for Order
}