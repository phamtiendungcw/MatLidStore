using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Commands.DeleteShoppingCartCommand;

public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, Unit>
{
    private readonly IAppLogger<DeleteShoppingCartCommandHandler> _logger;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public DeleteShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IAppLogger<DeleteShoppingCartCommandHandler> logger)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
    {
        var shoppingCartToDelete = await _shoppingCartRepository.GetByIdAsync(request.Id);

        if (shoppingCartToDelete is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the delete request.", nameof(ShoppingCart), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.ShoppingCart), request.Id);
        }

        await _shoppingCartRepository.DeleteAsync(shoppingCartToDelete);

        _logger.LogInformation("Shopping cart was deleted successfully!");
        return Unit.Value;
    }
}