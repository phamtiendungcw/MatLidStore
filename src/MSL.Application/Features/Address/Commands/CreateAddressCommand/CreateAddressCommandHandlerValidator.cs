using FluentValidation;

namespace MLS.Application.Features.Address.Commands.CreateAddressCommand
{
    public class CreateAddressCommandHandlerValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandHandlerValidator()
        {
            RuleFor(x => x.Address.Street)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(200).WithMessage("{PropertyName} must be fewer than 200 characters.");
            RuleFor(x => x.Address.City)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(20).WithMessage("{PropertyName} must be fewer than 20 characters.");
            RuleFor(x => x.Address.Country)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters.");
            RuleFor(x => x.Address.ZipCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(15).WithMessage("{PropertyName} must be fewer than 15 characters.");
        }
    }
}