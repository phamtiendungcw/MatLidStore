using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.OrderDetail.Commands.CreateOrderDetailCommand
{
    public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, int>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateOrderDetailDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OrderDetail);
            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Order Detail", validationResult);

            var orderDetailToCreate = _mapper.Map<Domain.Entities.OrderDetail>(request.OrderDetail);
            await _orderDetailRepository.CreateAsync(orderDetailToCreate);

            return orderDetailToCreate.Id;
        }
    }
}