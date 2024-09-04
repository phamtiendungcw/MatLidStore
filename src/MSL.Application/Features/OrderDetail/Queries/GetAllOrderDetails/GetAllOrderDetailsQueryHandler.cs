using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.OrderDetail.Queries.GetAllOrderDetails;

public class GetAllOrderDetailsQueryHandler : IRequestHandler<GetAllOrderDetailsQuery, List<OrderDetailDto>>
{
    private readonly IAppLogger<GetAllOrderDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public GetAllOrderDetailsQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper, IAppLogger<GetAllOrderDetailsQueryHandler> logger)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<OrderDetailDto>> Handle(GetAllOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var orderDetails = await _orderDetailRepository.GetAllAsync();
        var data = _mapper.Map<List<OrderDetailDto>>(orderDetails);

        _logger.LogInformation("Order details were retrieved successfully!");
        return data;
    }
}