using FluentValidation;

namespace MLS.Application.DTO.Address
{
    public class AddressDtoValidator : AbstractValidator<AddressDto>
    {
        public AddressDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street cannot be empty.")
                .MaximumLength(100).WithMessage("Street cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City cannot be empty.")
                .MaximumLength(50).WithMessage("City cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State cannot be empty.")
                .MaximumLength(50).WithMessage("State cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty.")
                .MaximumLength(50).WithMessage("Country cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("PostalCode cannot be empty.")
                .MaximumLength(20).WithMessage("Postal Code cannot be empty and must be less than 20 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class CreateAddressDtoValidator : AbstractValidator<CreateAddressDto>
    {
        public CreateAddressDtoValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street cannot be empty.")
                .MaximumLength(100).WithMessage("Street cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City cannot be empty.")
                .MaximumLength(50).WithMessage("City cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State cannot be empty.")
                .MaximumLength(50).WithMessage("State cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty.")
                .MaximumLength(50).WithMessage("Country cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("PostalCode cannot be empty.")
                .MaximumLength(20).WithMessage("Postal Code cannot be empty and must be less than 20 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateAddressDtoValidator : AbstractValidator<UpdateAddressDto>
    {
        public UpdateAddressDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Street)
                .NotEmpty().When(x => x.Street != null).WithMessage("Street cannot be empty.")
                .MaximumLength(100).WithMessage("Street cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().When(x => x.City != null).WithMessage("City cannot be empty.")
                .MaximumLength(50).WithMessage("City cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().When(x => x.State != null).WithMessage("State cannot be empty.")
                .MaximumLength(50).WithMessage("State cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().When(x => x.Country != null).WithMessage("Country cannot be empty.")
                .MaximumLength(50).WithMessage("Country cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.PostalCode)
                .NotEmpty().When(x => x.PostalCode != null).WithMessage("PostalCode cannot be empty.")
                .MaximumLength(20).WithMessage("Postal Code cannot be empty and must be less than 20 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}