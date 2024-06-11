using MediatR;
using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductOption;

namespace MLS.Application.Features.Product.Commands.UpdateProductCommand
{
    public class UpdateProductCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public List<ProductOptionDto> ProductOptions { get; set; } = new();
        public List<ProductColorDto> ProductColors { get; set; } = new();
        public List<string> Tags { get; set; } = new();
    }
}