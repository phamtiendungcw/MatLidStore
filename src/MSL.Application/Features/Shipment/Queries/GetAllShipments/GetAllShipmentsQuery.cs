using MediatR;
using MLS.Application.DTO.Shipment;

namespace MLS.Application.Features.Shipment.Queries.GetAllShipments;

public record GetAllShipmentsQuery : IRequest<List<ShipmentDto>>;