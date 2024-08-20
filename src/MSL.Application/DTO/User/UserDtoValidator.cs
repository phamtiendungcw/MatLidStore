using FluentValidation;

namespace MLS.Application.DTO.User;

public class UserDtoValidator : AbstractValidator<UserDto>
{
    public UserDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty().WithMessage("Id cannot be empty.");
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username cannot be empty.")
            .MaximumLength(50).WithMessage("Username must be less than 50 characters.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email address.");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName cannot be empty.")
            .MaximumLength(50).WithMessage("FirstName must be less than 50 characters.");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName cannot be empty.")
            .MaximumLength(50).WithMessage("LastName must be less than 50 characters.");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty.")
            .MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
    }
}

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username cannot be empty.")
            .MaximumLength(50).WithMessage("Username must be less than 50 characters.");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email address.");
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("FirstName cannot be empty.")
            .MaximumLength(50).WithMessage("FirstName must be less than 50 characters.");
        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("LastName cannot be empty.")
            .MaximumLength(50).WithMessage("LastName must be less than 50 characters.");
        RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("Phone cannot be empty.")
            .MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
    }
}

public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
{
    public UpdateUserDtoValidator()
    {
        RuleFor(x => x.Id)
            .NotNull().NotEmpty().WithMessage("Id cannot be empty.");
        RuleFor(x => x.UserName)
            .NotEmpty().When(x => x.UserName != null).WithMessage("Username cannot be empty.")
            .MaximumLength(50).WithMessage("Username must be less than 50 characters.");
        RuleFor(x => x.Email)
            .NotEmpty().When(x => x.Email != null).WithMessage("Email cannot be empty.")
            .EmailAddress().WithMessage("Invalid email address.");
        RuleFor(x => x.FirstName)
            .NotEmpty().When(x => x.FirstName != null).WithMessage("FirstName cannot be empty.")
            .MaximumLength(50).WithMessage("FirstName must be less than 50 characters.");
        RuleFor(x => x.LastName)
            .NotEmpty().When(x => x.LastName != null).WithMessage("LastName cannot be empty.")
            .MaximumLength(50).WithMessage("LastName must be less than 50 characters.");
        RuleFor(x => x.Phone)
            .NotEmpty().When(x => x.Phone != null).WithMessage("Phone cannot be empty.")
            .MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
    }
}

public class RegisterUserModelValidator : AbstractValidator<RegisterModel>
{
    public RegisterUserModelValidator()
    {
        RuleFor(x => x.Username)
            .NotNull()
            .NotEmpty().WithMessage("Username cannot be empty.")
            .MaximumLength(50).WithMessage("Username must be less than 50 characters.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password cannot be empty.");
    }
}