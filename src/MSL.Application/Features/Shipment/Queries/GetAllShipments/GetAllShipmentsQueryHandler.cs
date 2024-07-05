using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;

namespace MLS.Application.Features.Shipment.Queries.GetAllShipments;

public class GetAllShipmentsQueryHandler : IRequestHandler<GetAllShipmentsQuery, List<ShipmentDto>>
{
    private readonly IMapper _mapper;
    private readonly IShipmentRepository _shipmentRepository;

    public GetAllShipmentsQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper)
    {
        _shipmentRepository = shipmentRepository;
        _mapper = mapper;
    }

    public async Task<List<ShipmentDto>> Handle(GetAllShipmentsQuery request, CancellationToken cancellationToken)
    {
        var shipments = await _shipmentRepository.GetAllAsync();
        var data = _mapper.Map<List<ShipmentDto>>(shipments);

        return data;
    }
}