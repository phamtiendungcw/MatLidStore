using MediatR;
using MLS.Application.DTO.Payment;

namespace MLS.Application.Features.Payment.Queries.GetPaymentDetails
{
    public record GetPaymentDetailsQuery(int Id) : IRequest<PaymentDetailsDto>;
}