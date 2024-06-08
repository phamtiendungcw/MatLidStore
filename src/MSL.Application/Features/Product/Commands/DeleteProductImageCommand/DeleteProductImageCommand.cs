using MediatR;

namespace MLS.Application.Features.Product.Commands.DeleteProductImageCommand
{
    public class DeleteProductImageCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}