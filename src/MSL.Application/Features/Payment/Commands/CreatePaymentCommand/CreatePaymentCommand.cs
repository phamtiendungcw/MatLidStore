using MediatR;
using MLS.Application.DTO.Payment;

namespace MLS.Application.Features.Payment.Commands.CreatePaymentCommand
{
    public class CreatePaymentCommand : IRequest<int>
    {
        public CreatePaymentDto Payment { get; set; } = new();
    }
}