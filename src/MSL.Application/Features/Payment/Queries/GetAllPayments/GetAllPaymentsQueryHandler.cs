using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Payment;

namespace MLS.Application.Features.Payment.Queries.GetAllPayments;

public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentDto>>
{
    private readonly IAppLogger<GetAllPaymentsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public GetAllPaymentsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository, IAppLogger<GetAllPaymentsQueryHandler> logger)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
        _logger = logger;
    }

    public async Task<List<PaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await _paymentRepository.GetAllAsync();
        var data = _mapper.Map<List<PaymentDto>>(payments);

        _logger.LogInformation("Payments were retrieved successfully!");
        return data;
    }
}