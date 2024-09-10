using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Order;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Order.Commands.UpdateOrderCommand;

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Unit>
{
    private readonly IAppLogger<UpdateOrderCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public UpdateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IAppLogger<UpdateOrderCommandHandler> logger)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateOrderDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Order, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(Order), request.Order);
            throw new BadRequestException("Invalid Order", validationResult);
        }

        var orderToUpdate = _mapper.Map<Domain.Entities.Order>(request.Order);
        await _orderRepository.UpdateAsync(orderToUpdate);

        _logger.LogInformation("Order was updated successfully!");
        return Unit.Value;
    }
}