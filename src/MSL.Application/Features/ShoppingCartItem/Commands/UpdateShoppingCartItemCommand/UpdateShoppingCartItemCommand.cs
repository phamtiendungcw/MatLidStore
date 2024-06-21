using MediatR;
using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.Features.ShoppingCartItem.Commands.UpdateShoppingCartItemCommand
{
    public abstract class UpdateShoppingCartItemCommand : IRequest<Unit>
    {
        public UpdateShoppingCartItemDto ShoppingCartItem { get; set; } = null!;
    }
}