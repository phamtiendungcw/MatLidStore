using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ShoppingCart;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ShoppingCart.Queries.GetShoppingCartDetails
{
    public class GetShoppingCartDetailsQueryHandler : IRequestHandler<GetShoppingCartDetailsQuery, ShoppingCartDetailsDto>
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IMapper _mapper;

        public GetShoppingCartDetailsQueryHandler(IShoppingCartRepository shoppingCartRepository, IMapper mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _mapper = mapper;
        }

        public async Task<ShoppingCartDetailsDto> Handle(GetShoppingCartDetailsQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingCartRepository.GetByIdAsync(request.Id);

            if (shoppingCart is null)
                throw new NotFoundException(nameof(Domain.Entities.ShoppingCart), request.Id);

            var data = _mapper.Map<ShoppingCartDetailsDto>(shoppingCart);

            return data;
        }
    }
}