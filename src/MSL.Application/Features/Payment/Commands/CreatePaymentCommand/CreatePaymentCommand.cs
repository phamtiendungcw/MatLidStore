using MediatR;
using MLS.Application.DTO.Payment;

namespace MLS.Application.Features.Payment.Commands.CreatePaymentCommand
{
    public abstract class CreatePaymentCommand : IRequest<int>
    {
        public CreatePaymentDto Payment { get; set; }
    }
}