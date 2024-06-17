using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Shipment.Commands.CreateShipmentCommand
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, int>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentToCreate = _mapper.Map<Domain.Entities.Shipment>(request.Shipment);
            await _shipmentRepository.CreateAsync(shipmentToCreate);

            return shipmentToCreate.Id;
        }
    }
}