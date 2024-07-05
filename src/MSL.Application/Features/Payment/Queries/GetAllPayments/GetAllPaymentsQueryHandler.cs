using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Payment;

namespace MLS.Application.Features.Payment.Queries.GetAllPayments;

public class GetAllPaymentsQueryHandler : IRequestHandler<GetAllPaymentsQuery, List<PaymentDto>>
{
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public GetAllPaymentsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
    }

    public async Task<List<PaymentDto>> Handle(GetAllPaymentsQuery request, CancellationToken cancellationToken)
    {
        var payments = await _paymentRepository.GetAllAsync();
        var data = _mapper.Map<List<PaymentDto>>(payments);

        return data;
    }
}