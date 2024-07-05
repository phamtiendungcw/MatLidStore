using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Shipment.Commands.CreateShipmentCommand;

public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IShipmentRepository _shipmentRepository;

    public CreateShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper)
    {
        _shipmentRepository = shipmentRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateShipmentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Shipment, cancellationToken);
        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Shipment", validationResult);

        var shipmentToCreate = _mapper.Map<Domain.Entities.Shipment>(request.Shipment);
        await _shipmentRepository.CreateAsync(shipmentToCreate);

        return shipmentToCreate.Id;
    }
}