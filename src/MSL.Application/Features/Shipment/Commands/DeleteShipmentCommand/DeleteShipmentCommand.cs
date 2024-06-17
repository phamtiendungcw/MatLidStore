using MediatR;

namespace MLS.Application.Features.Shipment.Commands.DeleteShipmentCommand
{
    public abstract class DeleteShipmentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}