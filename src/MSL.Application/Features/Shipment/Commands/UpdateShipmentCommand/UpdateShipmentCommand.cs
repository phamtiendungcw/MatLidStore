using MediatR;
using MLS.Application.DTO.Shipment;

namespace MLS.Application.Features.Shipment.Commands.UpdateShipmentCommand
{
    public abstract class UpdateShipmentCommand : IRequest<Unit>
    {
        public UpdateShipmentDto Shipment { get; set; } = null!;
    }
}