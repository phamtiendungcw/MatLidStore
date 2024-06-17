using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Shipment.Queries.GetShipmentDetails
{
    public class GetShipmentDetailsQueryHandler : IRequestHandler<GetShipmentDetailsQuery, ShipmentDetailsDto>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public GetShipmentDetailsQueryHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<ShipmentDetailsDto> Handle(GetShipmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(request.Id);

            if (shipment is null)
                throw new NotFoundException(nameof(Domain.Entities.Shipment), request.Id);

            var data = _mapper.Map<ShipmentDetailsDto>(shipment);

            return data;
        }
    }
}