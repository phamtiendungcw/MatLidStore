using FluentValidation;

namespace MLS.Application.DTO.ProductColor
{
    public class CreateProductColorValidator : AbstractValidator<CreateProductColorDto>
    {
        public CreateProductColorValidator()
        {
            RuleFor(x => x.ColorName)
                .NotEmpty().WithMessage("ColorName cannot be empty.")
                .MaximumLength(50).WithMessage("Color Name cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.ColorHexCode)
                .NotEmpty().WithMessage("ColorHexCode cannot be empty.")
                .Matches("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$").WithMessage("Color Hex Code must be a valid hexadecimal value.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class UpdateProductColorValidator : AbstractValidator<UpdateProductColorDto>
    {
        public UpdateProductColorValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ColorName)
                .NotEmpty().WithMessage("ColorName cannot be empty.")
                .MaximumLength(50).WithMessage("Color Name cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.ColorHexCode)
                .NotEmpty().WithMessage("ColorHexCode cannot be empty.")
                .Matches("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$").WithMessage("Color Hex Code must be a valid hexadecimal value.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}