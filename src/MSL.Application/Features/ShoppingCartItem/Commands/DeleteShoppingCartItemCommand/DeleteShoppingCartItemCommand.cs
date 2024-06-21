using MediatR;

namespace MLS.Application.Features.ShoppingCartItem.Commands.DeleteShoppingCartItemCommand
{
    public class DeleteShoppingCartItemCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}