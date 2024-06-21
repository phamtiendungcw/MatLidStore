using MediatR;
using MLS.Application.DTO.Order;

namespace MLS.Application.Features.Order.Queries.GetAllOrders
{
    public record GetAllOrdersQuery : IRequest<List<OrderDto>>;
}