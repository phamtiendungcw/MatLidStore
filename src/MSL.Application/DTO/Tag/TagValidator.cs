using FluentValidation;

namespace MLS.Application.DTO.Tag
{
    public class CreateTagValidator : AbstractValidator<CreateTagDto>
    {
        public CreateTagValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
        }
    }

    public class UpdateTagValidator : AbstractValidator<UpdateTagDto>
    {
        public UpdateTagValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
        }
    }
}