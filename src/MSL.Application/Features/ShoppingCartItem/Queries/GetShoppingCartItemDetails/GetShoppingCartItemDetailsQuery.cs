using MediatR;
using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.Features.ShoppingCartItem.Queries.GetShoppingCartItemDetails
{
    public abstract record GetShoppingCartItemDetailsQuery(int Id) : IRequest<ShoppingCartItemDetailsDto>;
}