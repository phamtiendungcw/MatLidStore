using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.OrderDetail.Commands.UpdateOrderDetailCommand
{
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, Unit>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            var orderDetailToUpdate = _mapper.Map<Domain.Entities.OrderDetail>(request.OrderDetail);
            await _orderDetailRepository.UpdateAsync(orderDetailToUpdate);

            return Unit.Value;
        }
    }
}