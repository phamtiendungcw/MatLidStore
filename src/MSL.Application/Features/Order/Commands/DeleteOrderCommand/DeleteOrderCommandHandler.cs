using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Order.Commands.DeleteOrderCommand;

public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Unit>
{
    private readonly IAppLogger<DeleteOrderCommandHandler> _logger;
    private readonly IOrderRepository _orderRepository;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IAppLogger<DeleteOrderCommandHandler> logger)
    {
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
        var orderToDelete = await _orderRepository.GetByIdAsync(request.Id);

        if (orderToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(Order), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Order), request.Id);
        }

        await _orderRepository.DeleteAsync(orderToDelete);

        _logger.LogInformation("Order was deleted successfully!");
        return Unit.Value;
    }
}