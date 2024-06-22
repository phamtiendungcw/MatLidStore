using FluentValidation;

namespace MLS.Application.DTO.Discount
{
    public class DiscountDtoValidator : AbstractValidator<DiscountDto>
    {
        public DiscountDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code cannot be empty.")
                .MaximumLength(50).WithMessage("Code must be less than 50 characters.");
            RuleFor(x => x.Percentage)
                .InclusiveBetween(0, 100).WithMessage("Percentage must be between 0 and 100.");
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date must be less than or equal to End Date.");
        }
    }

    public class CreateDiscountDtoValidator : AbstractValidator<CreateDiscountDto>
    {
        public CreateDiscountDtoValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code cannot be empty.")
                .MaximumLength(50).WithMessage("Code must be less than 50 characters.");
            RuleFor(x => x.Percentage)
                .InclusiveBetween(0, 100).WithMessage("Percentage must be between 0 and 100.");
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date must be less than or equal to End Date.");
        }
    }

    public class UpdateDiscountDtoValidator : AbstractValidator<UpdateDiscountDto>
    {
        public UpdateDiscountDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Code)
                .NotEmpty().When(x => x.Code != null).WithMessage("Code cannot be empty.")
                .MaximumLength(50).WithMessage("Code must be less than 50 characters.");
            RuleFor(x => x.Percentage)
                .InclusiveBetween(0, 100).WithMessage("Percentage must be between 0 and 100.");
            RuleFor(x => x.StartDate)
                .LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date must be less than or equal to End Date.");
        }
    }
}