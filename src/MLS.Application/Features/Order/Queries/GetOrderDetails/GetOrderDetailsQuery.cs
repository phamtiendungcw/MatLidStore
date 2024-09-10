using MediatR;
using MLS.Application.DTO.Order;

namespace MLS.Application.Features.Order.Queries.GetOrderDetails;

public record GetOrderDetailsQuery(int Id) : IRequest<OrderDetailsDto>;