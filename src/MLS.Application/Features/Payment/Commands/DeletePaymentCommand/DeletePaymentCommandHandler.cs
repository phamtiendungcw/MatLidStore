using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Payment.Commands.DeletePaymentCommand;

public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Unit>
{
    private readonly IAppLogger<DeletePaymentCommandHandler> _logger;
    private readonly IPaymentRepository _paymentRepository;

    public DeletePaymentCommandHandler(IPaymentRepository paymentRepository, IAppLogger<DeletePaymentCommandHandler> logger)
    {
        _paymentRepository = paymentRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
    {
        var paymentToDelete = await _paymentRepository.GetByIdAsync(request.Id);

        if (paymentToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(Payment), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Payment), request.Id);
        }

        await _paymentRepository.DeleteAsync(paymentToDelete);

        _logger.LogInformation("Payment was deleted successfully!");
        return Unit.Value;
    }
}