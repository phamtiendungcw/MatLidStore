using MediatR;

namespace MLS.Application.Features.ShoppingCart.Commands.DeleteShoppingCartCommand
{
    public abstract class DeleteShoppingCartCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}