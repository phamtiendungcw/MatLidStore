using MLS.Application.DTO.Order;

namespace MLS.Application.DTO.Shipment
{
    public class ShipmentDetailsDto : ShipmentDto
    {
        public OrderDto Order { get; set; } = new();
    }
}