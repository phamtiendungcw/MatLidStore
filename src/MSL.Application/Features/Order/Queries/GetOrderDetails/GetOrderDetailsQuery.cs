using MediatR;
using MLS.Application.DTO.Order;

namespace MLS.Application.Features.Order.Queries.GetOrderDetails
{
    public abstract record GetOrderDetailsQuery(int Id) : IRequest<OrderDetailsDto>;
}