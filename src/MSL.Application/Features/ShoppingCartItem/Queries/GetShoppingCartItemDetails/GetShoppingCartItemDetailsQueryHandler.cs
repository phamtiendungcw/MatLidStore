using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Queries.GetShoppingCartItemDetails;

public class
    GetShoppingCartItemDetailsQueryHandler : IRequestHandler<GetShoppingCartItemDetailsQuery,
    ShoppingCartItemDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public GetShoppingCartItemDetailsQueryHandler(IShoppingCartItemRepository shoppingCartItemRepository,
        IMapper mapper)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _mapper = mapper;
    }

    public async Task<ShoppingCartItemDetailsDto> Handle(GetShoppingCartItemDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var shoppingCartItem = await _shoppingCartItemRepository.GetByIdAsync(request.Id);

        if (shoppingCartItem is null)
            throw new NotFoundException(nameof(Domain.Entities.ShoppingCartItem), request.Id);

        var data = _mapper.Map<ShoppingCartItemDetailsDto>(shoppingCartItem);

        return data;
    }
}