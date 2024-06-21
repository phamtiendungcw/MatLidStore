using MediatR;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Queries.GetShoppingCartDetails
{
    public record GetShoppingCartDetailsQuery(int Id) : IRequest<ShoppingCartDetailsDto>;
}