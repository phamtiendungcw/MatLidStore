using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCartItem.Queries.GetShoppingCartItemDetails;

public class
    GetShoppingCartItemDetailsQueryHandler : IRequestHandler<GetShoppingCartItemDetailsQuery,
    ShoppingCartItemDetailsDto>
{
    private readonly IAppLogger<GetShoppingCartItemDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShoppingCartItemRepository _shoppingCartItemRepository;

    public GetShoppingCartItemDetailsQueryHandler(IShoppingCartItemRepository shoppingCartItemRepository, IMapper mapper, IAppLogger<GetShoppingCartItemDetailsQueryHandler> logger)
    {
        _shoppingCartItemRepository = shoppingCartItemRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ShoppingCartItemDetailsDto> Handle(GetShoppingCartItemDetailsQuery request, CancellationToken cancellationToken)
    {
        var shoppingCartItem = await _shoppingCartItemRepository.GetByIdAsync(request.Id);

        if (shoppingCartItem is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(ShoppingCartItem), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.ShoppingCartItem), request.Id);
        }

        var data = _mapper.Map<ShoppingCartItemDetailsDto>(shoppingCartItem);

        _logger.LogInformation("Shopping cart item details were retrieved successfully!");
        return data;
    }
}