using MediatR;
using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.Features.ShoppingCartItem.Queries.GetAllShoppingCartItems
{
    public abstract record GetAllShoppingCartItemsQuery : IRequest<List<ShoppingCartItemDto>>;
}