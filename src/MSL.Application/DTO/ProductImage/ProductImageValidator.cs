using FluentValidation;

namespace MLS.Application.DTO.ProductImage
{
    public class CreateProductImageValidator : AbstractValidator<CreateProductImageDto>
    {
        public CreateProductImageValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl cannot be empty.")
                .MaximumLength(200).WithMessage("Image URL cannot be empty and must be less than 200 characters.");
            RuleFor(x => x.ImageDescription).MaximumLength(500).WithMessage("Image Description must be less than 500 characters.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class UpdateProductImageValidator : AbstractValidator<UpdateProductImageDto>
    {
        public UpdateProductImageValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl cannot be empty.")
                .MaximumLength(200).WithMessage("Image URL cannot be empty and must be less than 200 characters.");
            RuleFor(x => x.ImageDescription).MaximumLength(500).WithMessage("Image Description must be less than 500 characters.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}