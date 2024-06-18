using MediatR;

namespace MLS.Application.Features.OrderDetail.Commands.DeleteOrderDetailCommand
{
    public abstract class DeleteOrderDetailCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}