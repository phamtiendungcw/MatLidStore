using FluentValidation;

namespace MLS.Application.DTO.ProductColor
{
    public class ProductColorDtoValidator : AbstractValidator<ProductColorDto>
    {
        public ProductColorDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ColorName)
                .NotEmpty().WithMessage("ColorName cannot be empty.")
                .MaximumLength(50).WithMessage("ColorName must be less than 50 characters.");
            RuleFor(x => x.ColorHexCode)
                .NotEmpty().WithMessage("ColorHexCode cannot be empty.")
                .MaximumLength(7).WithMessage("ColorHexCode must be less than 7 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class CreateProductColorDtoValidator : AbstractValidator<CreateProductColorDto>
    {
        public CreateProductColorDtoValidator()
        {
            RuleFor(x => x.ColorName)
                .NotEmpty().WithMessage("ColorName cannot be empty.")
                .MaximumLength(50).WithMessage("ColorName must be less than 50 characters.");
            RuleFor(x => x.ColorHexCode)
                .NotEmpty().WithMessage("ColorHexCode cannot be empty.")
                .MaximumLength(7).WithMessage("ColorHexCode must be less than 7 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class UpdateProductColorDtoValidator : AbstractValidator<UpdateProductColorDto>
    {
        public UpdateProductColorDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ColorName)
                .NotEmpty().WithMessage("ColorName cannot be empty.")
                .MaximumLength(50).WithMessage("ColorName must be less than 50 characters.");
            RuleFor(x => x.ColorHexCode)
                .NotEmpty().WithMessage("ColorHexCode cannot be empty.")
                .MaximumLength(7).WithMessage("ColorHexCode must be less than 7 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}