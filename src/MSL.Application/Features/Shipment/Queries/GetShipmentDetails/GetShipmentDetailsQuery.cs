using MediatR;
using MLS.Application.DTO.Shipment;

namespace MLS.Application.Features.Shipment.Queries.GetShipmentDetails
{
    public record GetShipmentDetailsQuery(int Id) : IRequest<ShipmentDetailsDto>;
}