using FluentValidation;

namespace MLS.Application.DTO.Supplier
{
    public class CreateSupplierValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Contact cannot be empty.")
                .EmailAddress()
                .MaximumLength(100).WithMessage("Contact Email cannot be empty and must be a valid email address less than 100 characters.");
            RuleFor(x => x.ContactPhone)
                .NotEmpty()
                .MaximumLength(20).WithMessage("Contact Phone cannot be empty and must be less than 20 characters.");
        }
    }

    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("Contact cannot be empty.")
                .EmailAddress()
                .MaximumLength(100).WithMessage("Contact Email cannot be empty and must be a valid email address less than 100 characters.");
            RuleFor(x => x.ContactPhone)
                .NotEmpty()
                .MaximumLength(20).WithMessage("Contact Phone cannot be empty and must be less than 20 characters.");
        }
    }
}