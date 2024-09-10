using MediatR;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.OrderDetail.Commands.CreateOrderDetailCommand;

public class CreateOrderDetailCommand : IRequest<int>
{
    public CreateOrderDetailDto OrderDetail { get; set; } = new();
}