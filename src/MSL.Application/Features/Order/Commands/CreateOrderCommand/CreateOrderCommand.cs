using MediatR;
using MLS.Application.DTO.Order;

namespace MLS.Application.Features.Order.Commands.CreateOrderCommand;

public class CreateOrderCommand : IRequest<int>
{
    public CreateOrderCommand(CreateOrderDto order)
    {
        Order = order;
    }

    public CreateOrderDto Order { get; set; }
}