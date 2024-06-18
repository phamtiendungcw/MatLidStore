using FluentValidation;

namespace MLS.Application.DTO.User
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MaximumLength(50).WithMessage("Username cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().MaximumLength(100).WithMessage("Email cannot be empty and must be a valid email address less than 100 characters.");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("PasswordHash cannot be empty.")
                .MaximumLength(200).WithMessage("Password cannot be empty and must be less than 200 characters.");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("First Name must be less than 50 characters.");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Last Name must be less than 50 characters.");
            RuleFor(x => x.Phone).MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
        }
    }

    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MaximumLength(50).WithMessage("Username cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().MaximumLength(100).WithMessage("Email cannot be empty and must be a valid email address less than 100 characters.");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("PasswordHash cannot be empty.")
                .MaximumLength(200).WithMessage("Password cannot be empty and must be less than 200 characters.");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("First Name must be less than 50 characters.");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Last Name must be less than 50 characters.");
            RuleFor(x => x.Phone).MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
        }
    }
}