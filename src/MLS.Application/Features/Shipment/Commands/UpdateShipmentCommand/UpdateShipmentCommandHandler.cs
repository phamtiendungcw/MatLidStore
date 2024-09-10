using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Shipment.Commands.UpdateShipmentCommand;

public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, Unit>
{
    private readonly IAppLogger<UpdateShipmentCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShipmentRepository _shipmentRepository;

    public UpdateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, IAppLogger<UpdateShipmentCommandHandler> logger)
    {
        _shipmentRepository = shipmentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateShipmentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Shipment, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(Shipment), request.Shipment);
            throw new BadRequestException("Invalid shipment!", validationResult);
        }

        var shipmentToUpdate = _mapper.Map<Domain.Entities.Shipment>(request.Shipment);
        await _shipmentRepository.UpdateAsync(shipmentToUpdate);

        _logger.LogInformation("Shipment was updated successfully!");
        return Unit.Value;
    }
}