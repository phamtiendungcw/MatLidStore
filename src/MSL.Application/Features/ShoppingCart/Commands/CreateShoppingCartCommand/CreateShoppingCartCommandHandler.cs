using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.ShoppingCart.Commands.CreateShoppingCartCommand
{
    public class CreateShoppingCartCommandHandler : IRequestHandler<CreateShoppingCartCommand, int>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public CreateShoppingCartCommandHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateShoppingCartCommand request, CancellationToken cancellationToken)
        {
            var shoppingCartToCreate = _mapper.Map<Domain.Entities.ShoppingCart>(request.ShoppingCart);
            await _shoppingCartRepository.CreateAsync(shoppingCartToCreate);

            return shoppingCartToCreate.Id;
        }
    }
}