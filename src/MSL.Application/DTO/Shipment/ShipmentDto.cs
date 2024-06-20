namespace MLS.Application.DTO.Shipment
{
    public class ShipmentDto
    {
        public int Id { get; set; }
        public string ShippingMethod { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public int OrderId { get; set; }
    }
}