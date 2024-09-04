using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Payment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Payment.Queries.GetPaymentDetails;

public class GetPaymentDetailsQueryHandler : IRequestHandler<GetPaymentDetailsQuery, PaymentDetailsDto>
{
    private readonly IAppLogger<GetPaymentDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public GetPaymentDetailsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository, IAppLogger<GetPaymentDetailsQueryHandler> logger)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
        _logger = logger;
    }

    public async Task<PaymentDetailsDto> Handle(GetPaymentDetailsQuery request, CancellationToken cancellationToken)
    {
        var payment = await _paymentRepository.GetByIdAsync(request.Id);

        if (payment is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Payment), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Payment), request.Id);
        }

        var data = _mapper.Map<PaymentDetailsDto>(payment);

        _logger.LogInformation("Payment was retrieved successfully!");
        return data;
    }
}