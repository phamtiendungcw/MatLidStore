using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.OrderDetail.Commands.UpdateOrderDetailCommand;

public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommand, Unit>
{
    private readonly IAppLogger<UpdateOrderDetailCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IOrderDetailRepository _orderDetailRepository;

    public UpdateOrderDetailCommandHandler(IOrderDetailRepository orderDetailRepository, IMapper mapper, IAppLogger<UpdateOrderDetailCommandHandler> logger)
    {
        _orderDetailRepository = orderDetailRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateOrderDetailCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateOrderDetailDtoValidator();
        var validationResult = await validator.ValidateAsync(request.OrderDetail, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(OrderDetail), request.OrderDetail);
            throw new BadRequestException("Invalid order detail!", validationResult);
        }

        var orderDetailToUpdate = _mapper.Map<Domain.Entities.OrderDetail>(request.OrderDetail);
        await _orderDetailRepository.UpdateAsync(orderDetailToUpdate);

        _logger.LogInformation("Order detail was updated successfully!");
        return Unit.Value;
    }
}