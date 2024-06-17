using MediatR;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Queries.GetShoppingCartDetails
{
    public abstract record GetShoppingCartDetailsQuery(int Id) : IRequest<ShoppingCartDetailsDto>;
}