using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.Exceptions;

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
            // Validate data
            var validator = new UpdateOrderDetailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OrderDetail);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Order Detail", validationResult);

            var orderDetailToUpdate = _mapper.Map<Domain.Entities.OrderDetail>(request.OrderDetail);
            await _orderDetailRepository.UpdateAsync(orderDetailToUpdate);

            return Unit.Value;
        }
    }
}