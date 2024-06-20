using FluentValidation;

namespace MLS.Application.DTO.ProductTag
{
    public class ProductTagDtoValidator : AbstractValidator<ProductTagDto>
    {
        public ProductTagDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.TagName)
                .NotEmpty().WithMessage("TagName cannot be empty.")
                .MaximumLength(50).WithMessage("TagName must be less than 50 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage("TagId must be greater than 0.");
        }
    }

    public class CreateProductTagDtoValidator : AbstractValidator<CreateProductTagDto>
    {
        public CreateProductTagDtoValidator()
        {
            RuleFor(x => x.TagName)
                .NotEmpty().WithMessage("TagName cannot be empty.")
                .MaximumLength(50).WithMessage("TagName must be less than 50 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage("TagId must be greater than 0.");
        }
    }

    public class UpdateProductTagDtoValidator : AbstractValidator<UpdateProductTagDto>
    {
        public UpdateProductTagDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.TagName)
                .NotEmpty().WithMessage("TagName cannot be empty.")
                .MaximumLength(50).WithMessage("TagName must be less than 50 characters.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.TagId)
                .GreaterThan(0).WithMessage("TagId must be greater than 0.");
        }
    }
}