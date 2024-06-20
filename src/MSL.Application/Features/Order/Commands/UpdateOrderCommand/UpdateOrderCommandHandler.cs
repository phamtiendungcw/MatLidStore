using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Order;
using MLS.Application.Exceptions;

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
            // Validate data
            var validator = new UpdateOrderDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Order);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Order", validationResult);

            var orderToUpdate = _mapper.Map<Domain.Entities.Order>(request.Order);
            await _orderRepository.UpdateAsync(orderToUpdate);

            return Unit.Value;
        }
    }
}