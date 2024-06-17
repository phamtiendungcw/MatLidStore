using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.ShoppingCartItem.Commands.UpdateShoppingCartItemCommand
{
    public class UpdateShoppingCartItemCommandHandler : IRequestHandler<UpdateShoppingCartItemCommand, Unit>
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IMapper _mapper;

        public UpdateShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartItemToUpdate = _mapper.Map<Domain.Entities.ShoppingCartItem>(request.ShoppingCartItem);
            await _shoppingCartItemRepository.UpdateAsync(shoppingCartItemToUpdate);

            return Unit.Value;
        }
    }
}