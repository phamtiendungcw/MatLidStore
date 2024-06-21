using MediatR;
using MLS.Application.DTO.Payment;

namespace MLS.Application.Features.Payment.Commands.UpdatePaymentCommand
{
    public class UpdatePaymentCommand : IRequest<Unit>
    {
        public UpdatePaymentDto Payment { get; set; } = null!;
    }
}