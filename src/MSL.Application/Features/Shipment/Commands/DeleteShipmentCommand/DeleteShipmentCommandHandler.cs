using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Shipment.Commands.DeleteShipmentCommand;

public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, Unit>
{
    private readonly IShipmentRepository _shipmentRepository;

    public DeleteShipmentCommandHandler(IShipmentRepository shipmentRepository)
    {
        _shipmentRepository = shipmentRepository;
    }

    public async Task<Unit> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
    {
        var shipmentToDelete = await _shipmentRepository.GetByIdAsync(request.Id);

        if (shipmentToDelete is null)
            throw new NotFoundException(nameof(Domain.Entities.Shipment), request.Id);

        await _shipmentRepository.DeleteAsync(shipmentToDelete);

        return Unit.Value;
    }
}