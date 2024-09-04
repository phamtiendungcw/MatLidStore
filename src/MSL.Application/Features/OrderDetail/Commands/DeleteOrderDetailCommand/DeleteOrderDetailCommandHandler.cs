using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.OrderDetail.Commands.DeleteOrderDetailCommand;

public class DeleteOrderDetailCommandHandler : IRequestHandler<DeleteOrderDetailCommand, Unit>
{
    private readonly IAppLogger<DeleteOrderDetailCommandHandler> _logger;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public DeleteOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IAppLogger<DeleteOrderDetailCommandHandler> logger)
    {
        _orderDetailRepository = orderDetailRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteOrderDetailCommand request, CancellationToken cancellationToken)
    {
        var orderDetailToDelete = await _orderDetailRepository.GetByIdAsync(request.Id);

        if (orderDetailToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(OrderDetail), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.OrderDetail), request.Id);
        }

        await _orderDetailRepository.DeleteAsync(orderDetailToDelete);

        _logger.LogInformation("Order detail was deleted successfully!");
        return Unit.Value;
    }
}