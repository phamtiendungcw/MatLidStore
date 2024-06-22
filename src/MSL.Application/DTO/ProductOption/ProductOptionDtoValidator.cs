using FluentValidation;

namespace MLS.Application.DTO.ProductOption
{
    public class ProductOptionDtoValidator : AbstractValidator<ProductOptionDto>
    {
        public ProductOptionDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("Value must be greater than 0.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class CreateProductOptionDtoValidator : AbstractValidator<CreateProductOptionDto>
    {
        public CreateProductOptionDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("Value must be greater than 0.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class UpdateProductOptionDtoValidator : AbstractValidator<UpdateProductOptionDto>
    {
        public UpdateProductOptionDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().When(x => x.Name != null).WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.Value)
                .GreaterThan(0).WithMessage("Value must be greater than 0.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}