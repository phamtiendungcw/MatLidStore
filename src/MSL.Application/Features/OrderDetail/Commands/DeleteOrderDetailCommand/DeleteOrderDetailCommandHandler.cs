using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.OrderDetail.Commands.DeleteOrderDetailCommand;

public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, Unit>
{
    private readonly IOrderDetailRepository _orderDetailRepository;

    public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository)
    {
        _orderDetailRepository = orderDetailRepository;
    }

    public async Task<Unit> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetailToDelete = await _orderDetailRepository.GetByIdAsync(request.Id);

        if (orderDetailToDelete is null)
            throw new NotFoundException(nameof(Domain.Entities.OrderDetail), request.Id);

        await _orderDetailRepository.DeleteAsync(orderDetailToDelete);

        return Unit.Value;
    }
}