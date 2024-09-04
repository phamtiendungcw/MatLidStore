using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Order;

namespace MLS.Application.Features.Order.Queries.GetAllOrders;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDto>>
{
    private readonly IAppLogger<GetAllOrdersQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetAllOrdersQueryHandler(IMapper mapper, IOrderRepository orderRepository, IAppLogger<GetAllOrdersQueryHandler> logger)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<List<OrderDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await _orderRepository.GetAllAsync();
        var data = _mapper.Map<List<OrderDto>>(orders);

        _logger.LogInformation("Orders were retrieved successfully!");
        return data;
    }
}