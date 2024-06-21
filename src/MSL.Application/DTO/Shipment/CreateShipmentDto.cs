namespace MLS.Application.DTO.Shipment
{
    public class CreateShipmentDto
    {
        public string ShippingMethod { get; set; } = string.Empty;
        public string? TrackingNumber { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public int OrderId { get; set; }
    }
}