﻿using FluentValidation;

namespace MLS.Application.DTO.Address
{
    public class AddressValidator : AbstractValidator<AddressDto>
    {
        public AddressValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street cannot be empty.")
                .MaximumLength(100).WithMessage("Street cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City cannot be empty.").MaximumLength(50).WithMessage("City cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State cannot be empty.")
                .MaximumLength(50).WithMessage("State cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty.")
                .MaximumLength(50).WithMessage("Country cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("PostalCode cannot be empty.")
                .MaximumLength(20).WithMessage("Postal Code cannot be empty and must be less than 20 characters.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class CreateAddressValidator : AbstractValidator<CreateAddressDto>
    {
        public CreateAddressValidator()
        {
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street cannot be empty.")
                .MaximumLength(100).WithMessage("Street cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City cannot be empty.").MaximumLength(50).WithMessage("City cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State cannot be empty.")
                .MaximumLength(50).WithMessage("State cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty.")
                .MaximumLength(50).WithMessage("Country cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("PostalCode cannot be empty.")
                .MaximumLength(20).WithMessage("Postal Code cannot be empty and must be less than 20 characters.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateAddressValidator : AbstractValidator<UpdateAddressDto>
    {
        public UpdateAddressValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("Street cannot be empty.")
                .MaximumLength(100).WithMessage("Street cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City cannot be empty.").MaximumLength(50).WithMessage("City cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.State)
                .NotEmpty().WithMessage("State cannot be empty.")
                .MaximumLength(50).WithMessage("State cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country cannot be empty.")
                .MaximumLength(50).WithMessage("Country cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("PostalCode cannot be empty.")
                .MaximumLength(20).WithMessage("Postal Code cannot be empty and must be less than 20 characters.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}