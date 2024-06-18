using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.ShoppingCartItem.Commands.CreateShoppingCartItemCommand
{
    public class CreateShoppingCartItemCommandHandler : IRequestHandler<CreateShoppingCartItemCommand, int>
    {
        private readonly IShoppingCartItemRepository _shoppingCartItemRepository;
        private readonly IMapper _mapper;

        public CreateShoppingCartItemCommandHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper)
        {
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateShoppingCartItemCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartItemToCreate = _mapper.Map<Domain.Entities.ShoppingCartItem>(request.CartItem);
            await _shoppingCartItemRepository.CreateAsync(shoppingCartItemToCreate);

            return shoppingCartItemToCreate.Id;
        }
    }
}