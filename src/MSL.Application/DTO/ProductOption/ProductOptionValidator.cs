using FluentValidation;

namespace MLS.Application.DTO.ProductOption
{
    public class CreateProductOptionValidator : AbstractValidator<CreateProductOptionDto>
    {
        public CreateProductOptionValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0).WithMessage("Value must be greater than or equal to 0.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }

    public class UpdateProductOptionValidator : AbstractValidator<UpdateProductOptionDto>
    {
        public UpdateProductOptionValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.Value).GreaterThanOrEqualTo(0).WithMessage("Value must be greater than or equal to 0.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        }
    }
}