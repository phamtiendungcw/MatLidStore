using MediatR;
using MLS.Application.DTO.Order;

namespace MLS.Application.Features.Order.Commands.CreateOrderCommand
{
    public abstract class CreateOrderCommand : IRequest<int>
    {
        public CreateOrderDto Order { get; set; }
    }
}