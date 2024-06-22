using MediatR;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public UpdateProductDto Product { get; set; } = null!;
    }
}