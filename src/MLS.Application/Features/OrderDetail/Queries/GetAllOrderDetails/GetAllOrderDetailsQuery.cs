using MediatR;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.OrderDetail.Queries.GetAllOrderDetails;

public record GetAllOrderDetailsQuery : IRequest<List<OrderDetailDto>>;