using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.OrderDetail.Queries.GetOrderDetailDetails;

public class GetOrderDetailDetailsQueryHandler : IRequestHandler<GetOrderDetailDetailsQuery, OrderDetailDetailsDto>
{
    private readonly IAppLogger<GetOrderDetailDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public GetOrderDetailDetailsQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper, IAppLogger<GetOrderDetailDetailsQueryHandler> logger)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<OrderDetailDetailsDto> Handle(GetOrderDetailDetailsQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);

        if (orderDetail is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(OrderDetail), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.OrderDetail), request.Id);
        }

        var data = _mapper.Map<OrderDetailDetailsDto>(orderDetail);

        _logger.LogInformation("Order detail was retrieved successfully!");
        return data;
    }
}