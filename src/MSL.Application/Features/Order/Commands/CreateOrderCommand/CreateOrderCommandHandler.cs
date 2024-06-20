using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Order;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateOrderDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Order);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Order", validationResult);

            var orderToCreate = _mapper.Map<Domain.Entities.Order>(request);
            await _orderRepository.CreateAsync(orderToCreate);

            return orderToCreate.Id;
        }
    }
}