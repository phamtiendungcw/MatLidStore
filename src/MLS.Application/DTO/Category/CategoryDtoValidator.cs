using FluentValidation;

namespace MLS.Application.DTO.Category;

public class CategoryDtoValidator : AbstractValidator<CategoryDto>
{
    public CategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must be less than 500 characters.");
    }
}

public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
{
    public CreateCategoryDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must be less than 500 characters.");
    }
}

public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
{
    public UpdateCategoryDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.Name)
            .NotEmpty().When(x => x.Name != null).WithMessage("Name cannot be empty.")
            .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("Description must be less than 500 characters.");
    }
}