using FluentValidation;

namespace MLS.Application.DTO.Payment
{
    public class PaymentDtoValidator : AbstractValidator<PaymentDto>
    {
        public PaymentDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment Method cannot be empty.")
                .MaximumLength(50).WithMessage("Payment Method must be less than 50 characters.");
            RuleFor(x => x.AmountPaid)
                .GreaterThan(0).WithMessage("Amount Paid must be greater than 0.");
            RuleFor(x => x.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Payment Date cannot be in the future.");
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }

    public class CreatePaymentDtoValidator : AbstractValidator<CreatePaymentDto>
    {
        public CreatePaymentDtoValidator()
        {
            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Payment Method cannot be empty.")
                .MaximumLength(50).WithMessage("Payment Method must be less than 50 characters.");
            RuleFor(x => x.AmountPaid)
                .GreaterThan(0).WithMessage("Amount Paid must be greater than 0.");
            RuleFor(x => x.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Payment Date cannot be in the future.");
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }

    public class UpdatePaymentDtoValidator : AbstractValidator<UpdatePaymentDto>
    {
        public UpdatePaymentDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.PaymentMethod)
                .NotEmpty().When(x => x.PaymentMethod != null).WithMessage("Payment Method cannot be empty.")
                .MaximumLength(50).WithMessage("Payment Method must be less than 50 characters.");
            RuleFor(x => x.AmountPaid)
                .GreaterThan(0).WithMessage("Amount Paid must be greater than 0.");
            RuleFor(x => x.PaymentDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Payment Date cannot be in the future.");
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }
}