using MediatR;

namespace MLS.Application.Features.Product.Commands.DeleteProductCommand
{
    public abstract class DeleteProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}