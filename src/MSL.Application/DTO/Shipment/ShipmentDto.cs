using MLS.Application.DTO.Order;

namespace MLS.Application.DTO.Shipment
{
    public class ShipmentDto
    {
        public int Id { get; set; }
        public DateTime ShipmentDate { get; set; }
        public string Carrier { get; set; }
        public string TrackingNumber { get; set; }
        public int OrderId { get; set; }
        public OrderDto Order { get; set; }
    }
}