using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Payment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Payment.Commands.UpdatePaymentCommand;

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Unit>
{
    private readonly IAppLogger<UpdatePaymentCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public UpdatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository, IAppLogger<UpdatePaymentCommandHandler> logger)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdatePaymentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Payment, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(Payment), request.Payment);
            throw new BadRequestException("Invalid payment!", validationResult);
        }

        var paymentToUpdate = _mapper.Map<Domain.Entities.Payment>(request.Payment);
        await _paymentRepository.UpdateAsync(paymentToUpdate);

        _logger.LogInformation("Payment was updated successfully!");
        return Unit.Value;
    }
}