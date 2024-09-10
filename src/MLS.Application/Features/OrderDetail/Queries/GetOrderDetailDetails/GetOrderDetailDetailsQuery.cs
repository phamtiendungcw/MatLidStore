using MediatR;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.OrderDetail.Queries.GetOrderDetailDetails;

public record GetOrderDetailDetailsQuery(int Id) : IRequest<OrderDetailDetailsDto>;