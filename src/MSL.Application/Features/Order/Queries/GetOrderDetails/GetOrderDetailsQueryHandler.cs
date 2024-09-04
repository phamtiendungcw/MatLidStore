using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Order;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Order.Queries.GetOrderDetails;

public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsDto>
{
    private readonly IAppLogger<GetOrderDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public GetOrderDetailsQueryHandler(IMapper mapper, IOrderRepository orderRepository, IAppLogger<GetOrderDetailsQueryHandler> logger)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<OrderDetailsDto> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
    {
        var orderDetails = await _orderRepository.GetByIdAsync(request.Id);

        if (orderDetails is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Order), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Order), request.Id);
        }

        var data = _mapper.Map<OrderDetailsDto>(orderDetails);

        _logger.LogInformation("Order details were retrieved successfully!");
        return data;
    }
}