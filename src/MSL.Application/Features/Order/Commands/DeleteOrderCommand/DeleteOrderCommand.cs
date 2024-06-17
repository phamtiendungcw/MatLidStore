using MediatR;

namespace MLS.Application.Features.Order.Commands.DeleteOrderCommand
{
    public abstract class DeleteOrderCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}