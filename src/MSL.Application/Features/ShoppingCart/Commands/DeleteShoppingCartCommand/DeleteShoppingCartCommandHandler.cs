using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Commands.DeleteShoppingCartCommand
{
    public class DeleteShoppingCartCommandHandler : IRequestHandler<DeleteShoppingCartCommand, Unit>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public DeleteShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<Unit> Handle(DeleteShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartToDelete = await _shoppingCartRepository.GetByIdAsync(request.Id);

            if (shoppingCartToDelete is null)
                throw new NotFoundException(nameof(Domain.Entities.ShoppingCart), request.Id);

            await _shoppingCartRepository.DeleteAsync(shoppingCartToDelete);

            return Unit.Value;
        }
    }
}