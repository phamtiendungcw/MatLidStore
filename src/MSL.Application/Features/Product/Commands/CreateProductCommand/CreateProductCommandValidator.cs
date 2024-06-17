using FluentValidation;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductDto>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
    }
}