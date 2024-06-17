using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Queries.GetAllShoppingCarts
{
    public class GetAllShoppingCartsQueryHandler : IRequestHandler<GetAllShoppingCartsQuery, List<ShoppingCartDto>>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public GetAllShoppingCartsQueryHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<List<ShoppingCartDto>> Handle(GetAllShoppingCartsQuery request, CancellationToken cancellationToken)
        {
            var shoppingCarts = await _shoppingCartRepository.GetAllAsync();
            var data = _mapper.Map<List<ShoppingCartDto>>(shoppingCarts);

            return data;
        }
    }
}