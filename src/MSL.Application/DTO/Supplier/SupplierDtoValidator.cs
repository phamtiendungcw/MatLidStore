using FluentValidation;

namespace MLS.Application.DTO.Supplier
{
    public class SupplierDtoValidator : AbstractValidator<SupplierDto>
    {
        public SupplierDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("ContactEmail cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.ContactPhone)
                .NotEmpty().WithMessage("ContactPhone cannot be empty.")
                .MaximumLength(20).WithMessage("ContactPhone must be less than 20 characters.");
        }
    }

    public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDto>
    {
        public CreateSupplierDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().WithMessage("ContactEmail cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.ContactPhone)
                .NotEmpty().WithMessage("ContactPhone cannot be empty.")
                .MaximumLength(20).WithMessage("ContactPhone must be less than 20 characters.");
        }
    }

    public class UpdateSupplierDtoValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().When(x => x.Name != null).WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.ContactEmail)
                .NotEmpty().When(x => x.ContactEmail != null).WithMessage("ContactEmail cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.ContactPhone)
                .NotEmpty().When(x => x.ContactPhone != null).WithMessage("ContactPhone cannot be empty.")
                .MaximumLength(20).WithMessage("ContactPhone must be less than 20 characters.");
        }
    }
}