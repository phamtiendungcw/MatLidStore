using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;

namespace MLS.Application.Features.Shipment.Queries.GetAllShipments;

public class GetAllShipmentsQueryHandler : IRequestHandler<GetAllShipmentsQuery, List<ShipmentDto>>
{
    private readonly IAppLogger<GetAllShipmentsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShipmentRepository _shipmentRepository;

    public GetAllShipmentsQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, IAppLogger<GetAllShipmentsQueryHandler> logger)
    {
        _shipmentRepository = shipmentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<ShipmentDto>> Handle(GetAllShipmentsQuery request, CancellationToken cancellationToken)
    {
        var shipments = await _shipmentRepository.GetAllAsync();
        var data = _mapper.Map<List<ShipmentDto>>(shipments);

        _logger.LogInformation("Shipments were retrieved successfully!");
        return data;
    }
}