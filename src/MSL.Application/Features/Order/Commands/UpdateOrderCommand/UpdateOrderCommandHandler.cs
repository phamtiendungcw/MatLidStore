using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Order.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var orderToUpdate = _mapper.Map<Domain.Entities.Order>(request.Order);
            await _orderRepository.UpdateAsync(orderToUpdate);

            return Unit.Value;
        }
    }
}