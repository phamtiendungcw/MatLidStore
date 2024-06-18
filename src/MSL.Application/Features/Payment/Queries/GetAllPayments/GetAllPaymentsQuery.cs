using MediatR;
using MLS.Application.DTO.Payment;

namespace MLS.Application.Features.Payment.Queries.GetAllPayments
{
    public abstract record GetAllPaymentsQuery : IRequest<List<PaymentDto>>;
}