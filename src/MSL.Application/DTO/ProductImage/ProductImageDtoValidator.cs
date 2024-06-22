using FluentValidation;

namespace MLS.Application.DTO.ProductImage
{
    public class ProductImageDtoValidator : AbstractValidator<ProductImageDto>
    {
        public ProductImageDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl cannot be empty.")
                .MaximumLength(200).WithMessage("ImageUrl must be less than 200 characters.");
            RuleFor(x => x.ImageDescription)
                .MaximumLength(500).WithMessage("ImageDescription must be less than 500 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class CreateProductImageDtoValidator : AbstractValidator<CreateProductImageDto>
    {
        public CreateProductImageDtoValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("ImageUrl cannot be empty.")
                .MaximumLength(200).WithMessage("ImageUrl must be less than 200 characters.");
            RuleFor(x => x.ImageDescription)
                .MaximumLength(500).WithMessage("ImageDescription must be less than 500 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class UpdateProductImageDtoValidator : AbstractValidator<UpdateProductImageDto>
    {
        public UpdateProductImageDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ImageUrl)
                .NotEmpty().When(x => x.ImageUrl != null).WithMessage("ImageUrl cannot be empty.")
                .MaximumLength(200).WithMessage("ImageUrl must be less than 200 characters.");
            RuleFor(x => x.ImageDescription)
                .MaximumLength(500).WithMessage("ImageDescription must be less than 500 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}