using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Commands.DeleteShoppingCartItemCommand
{
    public class DeleteShoppingCartItemCommandHandler : IRequestHandler<DeleteShoppingCartItemCommand, Unit>
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

        public DeleteShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public async Task<Unit> Handle(DeleteShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartItemToDelete = await _shoppingCartItemRepository.GetByIdAsync(request.Id);

            if (shoppingCartItemToDelete is null)
                throw new NotFoundException(nameof(Domain.Entities.ShoppingCartItem), request.Id);

            await _shoppingCartItemRepository.DeleteAsync(shoppingCartItemToDelete);

            return Unit.Value;
        }
    }
}