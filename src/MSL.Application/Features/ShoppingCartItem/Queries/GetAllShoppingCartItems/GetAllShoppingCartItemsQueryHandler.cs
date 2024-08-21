using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.Features.ShoppingCartItem.Queries.GetAllShoppingCartItems;

public class
    GetAllShoppingCartItemsQueryHandler : IRequestHandler<GetAllShoppingCartItemsQuery, List<ShoppingCartItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public GetAllShoppingCartItemsQueryHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _mapper = mapper;
    }

    public async Task<List<ShoppingCartItemDto>> Handle(GetAllShoppingCartItemsQuery request,
        CancellationToken cancellationToken)
    {
        var shoppingCartItems = await _shoppingCartItemRepository.GetAllAsync();
        var data = _mapper.Map<List<ShoppingCartItemDto>>(shoppingCartItems);

        return data;
    }
}