using FluentValidation;

namespace MLS.Application.DTO.Discount
{
    public class CreateDiscountValidator : AbstractValidator<CreateDiscountDto>
    {
        public CreateDiscountValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code cannot be empty.")
                .MaximumLength(50).WithMessage("Code cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Percentage).InclusiveBetween(0, 100).WithMessage("Percentage must be between 0 and 100.");
            RuleFor(x => x.StartDate).LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date must be less than or equal to End Date.");
        }
    }

    public class UpdateDiscountValidator : AbstractValidator<UpdateDiscountDto>
    {
        public UpdateDiscountValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code cannot be empty.")
                .MaximumLength(50).WithMessage("Code cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Percentage).InclusiveBetween(0, 100).WithMessage("Percentage must be between 0 and 100.");
            RuleFor(x => x.StartDate).LessThanOrEqualTo(x => x.EndDate).WithMessage("Start Date must be less than or equal to End Date.");
        }
    }
}