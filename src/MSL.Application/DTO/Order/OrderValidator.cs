using FluentValidation;

namespace MLS.Application.DTO.Order
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.OrderDate).LessThanOrEqualTo(DateTime.Now).WithMessage("Order Date cannot be in the future.");
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("Total Price must be greater than 0.");
            RuleFor(x => x.OrderStatus)
                .NotEmpty().WithMessage("OrderStatus cannot be empty.")
                .MaximumLength(50).WithMessage("Order Status cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateOrderValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.OrderDate).LessThanOrEqualTo(DateTime.Now).WithMessage("Order Date cannot be in the future.");
            RuleFor(x => x.TotalPrice).GreaterThan(0).WithMessage("Total Price must be greater than 0.");
            RuleFor(x => x.OrderStatus)
                .NotEmpty().WithMessage("OrderStatus cannot be empty.")
                .MaximumLength(50).WithMessage("Order Status cannot be empty and must be less than 50 characters.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}