using MediatR;

namespace MLS.Application.Features.OrderDetail.Commands.DeleteOrderDetailCommand;

public class DeleteOrderDetailCommand : IRequest<Unit>
{
    public int Id { get; set; }
}