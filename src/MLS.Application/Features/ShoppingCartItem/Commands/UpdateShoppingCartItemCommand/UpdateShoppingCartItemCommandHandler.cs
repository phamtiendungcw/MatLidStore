using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Commands.UpdateShoppingCartItemCommand;

public class UpdateShoppingCartItemCommandHandler : IRequestHandler<UpdateShoppingCartItemCommand, Unit>
{
    private readonly IAppLogger<UpdateShoppingCartItemCommandHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public UpdateShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper, IAppLogger<UpdateShoppingCartItemCommandHandler> logger)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateShoppingCartItemCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateShoppingCartItemDtoValidator();
        var validationResult = await validator.ValidateAsync(request.ShoppingCartItem, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Invalid errors in update request for {0} - {1}.", nameof(ShoppingCartItem), request.ShoppingCartItem);
            throw new BadRequestException("Invalid shopping cart item!", validationResult);
        }

        var shoppingCartItemToUpdate = _mapper.Map<Domain.Entities.ShoppingCartItem>(request.ShoppingCartItem);
        await _shoppingCartItemRepository.UpdateAsync(shoppingCartItemToUpdate);

        _logger.LogInformation("Shopping cart item was updated successfully!");
        return Unit.Value;
    }
}