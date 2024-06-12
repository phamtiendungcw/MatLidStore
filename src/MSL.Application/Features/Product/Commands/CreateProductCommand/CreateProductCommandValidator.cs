using FluentValidation;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandValidator(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name is required.")
                .MaximumLength(200).WithMessage("Product name cannot exceed 200 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Product description is required.");

            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Product price must be greater than zero.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Category is required.");

            RuleFor(q => q)
                .MustAsync(ProductNameUnique)
                .WithMessage("Product name already exists.");
        }

        private Task<bool> ProductNameUnique(CreateProductCommand command, CancellationToken token)
        {
            return _productRepository.IsProductUnique(command.Name);
        }
    }
}