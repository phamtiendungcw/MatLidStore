using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Shipment.Commands.DeleteShipmentCommand;

public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, Unit>
{
    private readonly IAppLogger<DeleteShipmentCommandHandler> _logger;
    private readonly IShipmentRepository _shipmentRepository;

    public DeleteShipmentCommandHandler(IShipmentRepository shipmentRepository, IAppLogger<DeleteShipmentCommandHandler> logger)
    {
        _shipmentRepository = shipmentRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
    {
        var shipmentToDelete = await _shipmentRepository.GetByIdAsync(request.Id);

        if (shipmentToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(Shipment), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Shipment), request.Id);
        }

        await _shipmentRepository.DeleteAsync(shipmentToDelete);

        _logger.LogInformation("Shipment was deleted successfully!");
        return Unit.Value;
    }
}