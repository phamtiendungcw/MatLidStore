using MediatR;
using MLS.Application.DTO.Order;

namespace MLS.Application.Features.Order.Commands.UpdateOrderCommand
{
    public class UpdateOrderCommand : IRequest<Unit>
    {
        public UpdateOrderDto Order { get; set; } = null!;
    }
}