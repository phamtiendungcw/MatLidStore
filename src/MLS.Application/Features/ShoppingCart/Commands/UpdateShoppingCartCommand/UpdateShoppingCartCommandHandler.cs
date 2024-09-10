using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Commands.UpdateShoppingCartCommand;

public class UpdateShoppingCartCommandHandler : IRequestHandler<UpdateShoppingCartCommand, Unit>
{
    private readonly IAppLogger<UpdateShoppingCartCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public UpdateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper, IAppLogger<UpdateShoppingCartCommandHandler> logger)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateShoppingCartCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateShoppingCartDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShoppingCart, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(ShoppingCart), request.ShoppingCart);
            throw new BadRequestException("Invalid shopping cart!", validationResult);
        }

        var shoppingCartToUpdate = _mapper.Map<Domain.Entities.ShoppingCart>(request.ShoppingCart);
        await _shoppingCartRepository.UpdateAsync(shoppingCartToUpdate);

        _logger.LogInformation("Shopping cart was updated successfully!");
        return Unit.Value;
    }
}