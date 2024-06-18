using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Shipment.Commands.UpdateShipmentCommand
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, Unit>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public UpdateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper)
        {
            _shipmentRepository = shipmentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentToUpdate = _mapper.Map<Domain.Entities.Shipment>(request.Shipment);
            await _shipmentRepository.UpdateAsync(shipmentToUpdate);

            return Unit.Value;
        }
    }
}