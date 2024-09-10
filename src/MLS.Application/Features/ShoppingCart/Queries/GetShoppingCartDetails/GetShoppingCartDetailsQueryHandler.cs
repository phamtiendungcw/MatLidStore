using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Queries.GetShoppingCartDetails;

public class GetShoppingCartDetailsQueryHandler : IRequestHandler<GetShoppingCartDetailsQuery, ShoppingCartDetailsDto>
{
    private readonly IAppLogger<GetShoppingCartDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IShoppingCartRepository _shoppingCartRepository;

    public GetShoppingCartDetailsQueryHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper, IAppLogger<GetShoppingCartDetailsQueryHandler> logger)
    {
        _shoppingCartRepository = shoppingCartRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ShoppingCartDetailsDto> Handle(GetShoppingCartDetailsQuery request, CancellationToken cancellationToken)
    {
        var shoppingCart = await _shoppingCartRepository.GetByIdAsync(request.Id);

        if (shoppingCart is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(ShoppingCart), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.ShoppingCart), request.Id);
        }

        var data = _mapper.Map<ShoppingCartDetailsDto>(shoppingCart);

        _logger.LogInformation("Shopping cart details were retrieved successfully!");
        return data;
    }
}