using MediatR;

namespace MLS.Application.Features.Payment.Commands.DeletePaymentCommand
{
    public abstract class DeletePaymentCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}