using MediatR;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.OrderDetail.Queries.GetOrderDetailDetails
{
    public abstract record GetOrderDetailDetailsQuery(int Id) : IRequest<OrderDetailDetailsDto>;
}