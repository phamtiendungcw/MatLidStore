using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Queries.GetAllShoppingCarts;

public class GetAllShoppingCartsQueryHandler : IRequestHandler<GetAllShoppingCartsQuery, List<ShoppingCartDto>>
{
    private readonly IAppLogger<GetAllShoppingCartsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public GetAllShoppingCartsQueryHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper, IAppLogger<GetAllShoppingCartsQueryHandler> logger)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<ShoppingCartDto>> Handle(GetAllShoppingCartsQuery request, CancellationToken cancellationToken)
    {
        var shoppingCarts = await _shoppingCartRepository.GetAllAsync();
        var data = _mapper.Map<List<ShoppingCartDto>>(shoppingCarts);

        _logger.LogInformation("Shopping carts were retrieved successfully!");
        return data;
    }
}