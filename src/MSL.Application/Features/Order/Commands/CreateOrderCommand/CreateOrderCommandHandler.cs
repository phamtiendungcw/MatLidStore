using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Order;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Order.Commands.CreateOrderCommand;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, int>
{
    private readonly IAppLogger<CreateOrderCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IMapper mapper, IOrderRepository orderRepository, IAppLogger<CreateOrderCommandHandler> logger)
    {
        _mapper = mapper;
        _orderRepository = orderRepository;
        _logger = logger;
    }

    public async Task<int> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateOrderDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Order, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validator errors in create for {0} - {1}.", nameof(Order), request.Order);
            throw new BadRequestException("Invalid Order!", validationResult);
        }

        var orderToCreate = _mapper.Map<Domain.Entities.Order>(request.Order);
        await _orderRepository.CreateAsync(orderToCreate);

        _logger.LogInformation("Order was created successfully!");
        return orderToCreate.Id;
    }
}