﻿using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence;

namespace MLS.Application.Features.Delivery.Commands.CreateDeliveryCommand
{
    public class CreateDeliveryCommandHandler : IRequestHandler<CreateDeliveryCommand, int>
    {
        private readonly IDeliveryRepository _deliveryRepository;
        private readonly IMapper _mapper;

        public CreateDeliveryCommandHandler(IDeliveryRepository deliveryRepository, IMapper mapper)
        {
            _deliveryRepository = deliveryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDeliveryCommand request, CancellationToken cancellationToken)
        {
            var deliveryToCreate = _mapper.Map<Domain.Entities.Delivery>(request);
            await _deliveryRepository.Create(deliveryToCreate);

            return deliveryToCreate.Id;
        }
    }
}