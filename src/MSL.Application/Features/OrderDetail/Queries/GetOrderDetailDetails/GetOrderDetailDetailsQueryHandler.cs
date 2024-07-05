using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.OrderDetail.Queries.GetOrderDetailDetails;

public class GetOrderDetailDetailsQueryHandler : IRequestHandler<GetOrderDetailDetailsQuery, OrderDetailDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public GetOrderDetailDetailsQueryHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
    }

    public async Task<OrderDetailDetailsDto> Handle(GetOrderDetailDetailsQuery request, CancellationToken cancellationToken)
    {
        var orderDetail = await _orderDetailRepository.GetByIdAsync(request.Id);

        if (orderDetail is null)
            throw new NotFoundException(nameof(Domain.Entities.OrderDetail), request.Id);

        var data = _mapper.Map<OrderDetailDetailsDto>(orderDetail);

        return data;
    }
}