using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.OrderDetail.Commands.CreateOrderDetailCommand;

public class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, int>
{
    private readonly IAppLogger<CreateOrderDetailCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public CreateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper, IAppLogger<CreateOrderDetailCommandHandler> logger)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateOrderDetailDtoValidator();
        var validationResult = await validator.ValidateAsync(request.OrderDetail, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(OrderDetail), request.OrderDetail);
            throw new BadRequestException("Invalid order detail!", validationResult);
        }

        var orderDetailToCreate = _mapper.Map<Domain.Entities.OrderDetail>(request.OrderDetail);
        await _orderDetailRepository.CreateAsync(orderDetailToCreate);

        _logger.LogInformation("Order detail was created successfully!");
        return orderDetailToCreate.Id;
    }
}