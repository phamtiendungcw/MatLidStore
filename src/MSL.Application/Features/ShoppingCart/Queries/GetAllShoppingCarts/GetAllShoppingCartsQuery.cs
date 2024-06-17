using MediatR;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Queries.GetAllShoppingCarts
{
    public abstract record GetAllShoppingCartsQuery : IRequest<List<ShoppingCartDto>>;
}