﻿using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Shipment;
using MLS.Application.Exceptions;

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
            // Validate data
            var validator = new UpdateShipmentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Shipment);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Shipment", validationResult);

            var shipmentToUpdate = _mapper.Map<Domain.Entities.Shipment>(request.Shipment);
            await _shipmentRepository.UpdateAsync(shipmentToUpdate);

            return Unit.Value;
        }
    }
}