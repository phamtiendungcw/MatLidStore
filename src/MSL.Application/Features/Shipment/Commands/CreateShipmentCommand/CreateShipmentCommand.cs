using MediatR;
using MLS.Application.DTO.Shipment;

namespace MLS.Application.Features.Shipment.Commands.CreateShipmentCommand
{
    public abstract class CreateShipmentCommand : IRequest<int>
    {
        public CreateShipmentDto Shipment { get; set; } = new();
    }
}