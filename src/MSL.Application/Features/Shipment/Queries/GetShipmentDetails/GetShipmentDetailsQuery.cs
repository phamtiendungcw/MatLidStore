using MediatR;
using MLS.Application.DTO.Shipment;

namespace MLS.Application.Features.Shipment.Queries.GetShipmentDetails
{
    public abstract record GetShipmentDetailsQuery(int Id) : IRequest<ShipmentDetailsDto>;
}