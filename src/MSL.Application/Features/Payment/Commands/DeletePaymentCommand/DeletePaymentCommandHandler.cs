using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Payment.Commands.DeletePaymentCommand
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Unit>
    {
        private readonly IPaymentRepository _paymentRepository;

        public DeletePaymentCommandHandler(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<Unit> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentToDelete = await _paymentRepository.GetByIdAsync(request.Id);

            if (paymentToDelete is null)
                throw new NotFoundException(nameof(Domain.Entities.Payment), request.Id);

            await _paymentRepository.DeleteAsync(paymentToDelete);

            return Unit.Value;
        }
    }
}