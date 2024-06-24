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
        private readonly IOrderDetailRepository _orderDetailRepository;

        public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateOrderDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Order, cancellationToken);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Order", validationResult);

            var orderToCreate = _mapper.Map<Domain.Entities.Order>(request.Order);
            await _orderRepository.CreateAsync(orderToCreate);

            return orderToCreate.Id;
        }
    }
}