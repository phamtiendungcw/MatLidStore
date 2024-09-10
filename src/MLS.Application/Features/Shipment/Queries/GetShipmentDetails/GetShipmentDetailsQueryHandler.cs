using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Shipment.Queries.GetShipmentDetails;

public class GetShipmentDetailsQueryHandler : IRequestHandler<GetShipmentDetailsQuery, ShipmentDetailsDto>
{
    private readonly IAppLogger<GetShipmentDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShipmentRepository _shipmentRepository;

    public GetShipmentDetailsQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper, IAppLogger<GetShipmentDetailsQueryHandler> logger)
    {
        _shipmentRepository = shipmentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ShipmentDetailsDto> Handle(GetShipmentDetailsQuery request, CancellationToken cancellationToken)
    {
        var shipment = await _shipmentRepository.GetByIdAsync(request.Id);

        if (shipment is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Shipment), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Shipment), request.Id);
        }

        var data = _mapper.Map<ShipmentDetailsDto>(shipment);

        _logger.LogInformation("Shipment details were retrieved successfully!");
        return data;
    }
}