using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Payment.Commands.UpdatePaymentCommand;

public class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public UpdatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
    }

    public async Task<Unit> Handle(UpdatePaymentCommand request, CancellationToken cancellationToken)
    {
        var paymentToUpdate = _mapper.Map<Domain.Entities.Payment>(request.Payment);
        await _paymentRepository.UpdateAsync(paymentToUpdate);

        return Unit.Value;
    }
}