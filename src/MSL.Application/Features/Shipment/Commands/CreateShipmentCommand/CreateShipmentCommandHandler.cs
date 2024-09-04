using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Shipment.Commands.CreateShipmentCommand;

public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, int>
{
    private readonly IAppLogger<CreateShipmentCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShipmentRepository _shipmentRepository;

    public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, IAppLogger<CreateShipmentCommandHandler> logger)
    {
        _shipmentRepository = shipmentRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateShipmentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Shipment, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(Shipment), request.Shipment);
            throw new BadRequestException("Invalid shipment!", validationResult);
        }

        var shipmentToCreate = _mapper.Map<Domain.Entities.Shipment>(request.Shipment);
        await _shipmentRepository.CreateAsync(shipmentToCreate);

        _logger.LogInformation("Shipment was created successfully!");
        return shipmentToCreate.Id;
    }
}