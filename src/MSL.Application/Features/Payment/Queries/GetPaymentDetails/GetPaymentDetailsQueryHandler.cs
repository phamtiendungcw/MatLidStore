using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Payment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Payment.Queries.GetPaymentDetails
{
    public class GetPaymentDetailsQueryHandler : IRequestHandler<GetPaymentDetailsQuery, PaymentDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IPaymentRepository _paymentRepository;

        public GetPaymentDetailsQueryHandler(IMapper mapper, IPaymentRepository paymentRepository)
        {
            _mapper = mapper;
            _paymentRepository = paymentRepository;
        }

        public async Task<PaymentDetailsDto> Handle(GetPaymentDetailsQuery request, CancellationToken cancellationToken)
        {
            var payment = await _paymentRepository.GetByIdAsync(request.Id);

            if (payment is null)
                throw new NotFoundException(nameof(Domain.Entities.Payment), request.Id);

            var data = _mapper.Map<PaymentDetailsDto>(payment);

            return data;
        }
    }
}