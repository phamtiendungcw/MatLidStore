using MediatR;
using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductOption;

namespace MLS.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public int CategoryId { get; set; }
        public List<ProductOptionDto> ProductOptions { get; set; } = new();
        public List<ProductColorDto> ProductColors { get; set; } = new();
        public List<string> Tags { get; set; } = new();
    }
}