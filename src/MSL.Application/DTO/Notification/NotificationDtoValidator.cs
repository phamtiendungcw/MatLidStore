using FluentValidation;

namespace MLS.Application.DTO.Notification
{
    public class NotificationDtoValidator : AbstractValidator<NotificationDto>
    {
        public NotificationDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message cannot be empty.")
                .MaximumLength(500).WithMessage("Message must be less than 500 characters.");
            RuleFor(x => x.Timestamp)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Timestamp cannot be in the future.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class CreateNotificationDtoValidator : AbstractValidator<CreateNotificationDto>
    {
        public CreateNotificationDtoValidator()
        {
            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message cannot be empty.")
                .MaximumLength(500).WithMessage("Message must be less than 500 characters.");
            RuleFor(x => x.Timestamp)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Timestamp cannot be in the future.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateNotificationDtoValidator : AbstractValidator<UpdateNotificationDto>
    {
        public UpdateNotificationDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Message)
                .NotEmpty().When(x => x.Message != null).WithMessage("Message cannot be empty.")
                .MaximumLength(500).WithMessage("Message must be less than 500 characters.");
            RuleFor(x => x.Timestamp)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Timestamp cannot be in the future.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}