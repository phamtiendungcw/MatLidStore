using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Payment.Commands.CreatePaymentCommand;

public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IPaymentRepository _paymentRepository;

    public CreatePaymentCommandHandler(IMapper mapper, IPaymentRepository paymentRepository)
    {
        _mapper = mapper;
        _paymentRepository = paymentRepository;
    }

    public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
    {
        var paymentToCreate = _mapper.Map<Domain.Entities.Payment>(request.Payment);
        await _paymentRepository.CreateAsync(paymentToCreate);

        return paymentToCreate.Id;
    }
}