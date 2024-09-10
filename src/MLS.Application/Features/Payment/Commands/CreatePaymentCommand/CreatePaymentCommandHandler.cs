using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Payment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Payment.Commands.CreatePaymentCommand;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IAppLogger<CreatePaymentCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository, IAppLogger<CreatePaymentCommandHandler> logger)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
        _logger = logger;
    }

    public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreatePaymentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Payment, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(Payment), request.Payment);
            throw new BadRequestException("Invalid payment!", validationResult);
        }

        var paymentToCreate = _mapper.Map<Domain.Entities.Payment>(request.Payment);
        await _paymentRepository.CreateAsync(paymentToCreate);

        _logger.LogInformation("Payment was created successfully!");
        return paymentToCreate.Id;
    }
}