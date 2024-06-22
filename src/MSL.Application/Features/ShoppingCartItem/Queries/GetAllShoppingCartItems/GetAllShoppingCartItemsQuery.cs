using MediatR;
using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.Features.ShoppingCartItem.Queries.GetAllShoppingCartItems
{
    public record GetAllShoppingCartItemsQuery : IRequest<List<ShoppingCartItemDto>>;
}