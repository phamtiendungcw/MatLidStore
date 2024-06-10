namespace MLS.Domain.Entities
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime EstimatedArrivalDate { get; set; }
    }
}