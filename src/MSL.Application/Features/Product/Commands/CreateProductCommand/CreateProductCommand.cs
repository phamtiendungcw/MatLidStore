using MediatR;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<int>
    {
        public CreateProductDto Product { get; set; } = new();
    }
}