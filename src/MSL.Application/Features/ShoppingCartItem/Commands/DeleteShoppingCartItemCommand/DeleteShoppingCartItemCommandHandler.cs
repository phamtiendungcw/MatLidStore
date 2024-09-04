using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Commands.DeleteShoppingCartItemCommand;

public class DeleteShoppingCartItemCommandHandler : IRequestHandler<DeleteShoppingCartItemCommand, Unit>
{
    private readonly IAppLogger<DeleteShoppingCartItemCommandHandler> _logger;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public DeleteShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository, IAppLogger<DeleteShoppingCartItemCommandHandler> logger)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteShoppingCartItemCommand request, CancellationToken cancellationToken)
    {
        var shoppingCartItemToDelete = await _shoppingCartItemRepository.GetByIdAsync(request.Id);

        if (shoppingCartItemToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(ShoppingCartItem), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.ShoppingCartItem), request.Id);
        }

        await _shoppingCartItemRepository.DeleteAsync(shoppingCartItemToDelete);

        _logger.LogInformation("Shopping cart item was deleted successfully!");
        return Unit.Value;
    }
}