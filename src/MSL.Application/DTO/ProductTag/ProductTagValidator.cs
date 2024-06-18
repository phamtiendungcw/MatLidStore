using FluentValidation;

namespace MLS.Application.DTO.ProductTag
{
    public class CreateProductTagValidator : AbstractValidator<CreateProductTagDto>
    {
        public CreateProductTagValidator()
        {
            RuleFor(x => x.TagName)
                .NotEmpty().WithMessage("TagName cannot be empty.")
                .MaximumLength(100).WithMessage("Tag Name cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.TagId).GreaterThan(0).WithMessage("TagId must be greater than 0.");
        }

        public class UpdateProductTagValidator : AbstractValidator<UpdateProductTagDto>
        {
            public UpdateProductTagValidator()
            {
                RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
                RuleFor(x => x.TagName)
                    .NotEmpty().WithMessage("TagName cannot be empty.")
                    .MaximumLength(100).WithMessage("Tag Name cannot be empty and must be less than 100 characters.");
                RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
                RuleFor(x => x.TagId).GreaterThan(0).WithMessage("TagId must be greater than 0.");
            }
        }
    }
}