using FluentValidation;

namespace MLS.Application.DTO.Category
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must be less than 500 characters.");
        }
    }

    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description must be less than 500 characters.");
        }
    }
}