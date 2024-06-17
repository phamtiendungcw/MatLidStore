using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.OrderDetail.Queries.GetAllOrderDetails
{
    public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, List<OrderDetailDto>>
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public GetAllOrderDetailsQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderDetailDto>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailRepository.GetAllAsync();
            var data = _mapper.Map<List<OrderDetailDto>>(orderDetails);

            return data;
        }
    }
}