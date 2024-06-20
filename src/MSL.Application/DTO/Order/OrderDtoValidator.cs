using FluentValidation;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.DTO.Order
{
    public class OrderDtoValidator : AbstractValidator<OrderDto>
    {
        public OrderDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order Date cannot be in the future.");
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total Price must be greater than 0.");
            RuleFor(x => x.OrderStatus)
                .NotEmpty().WithMessage("Order Status cannot be empty.")
                .MaximumLength(50).WithMessage("Order Status must be less than 50 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.OrderDetails)
                .SetValidator(new OrderDetailDtoValidator());
        }
    }

    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator()
        {
            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order Date cannot be in the future.");
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total Price must be greater than 0.");
            RuleFor(x => x.OrderStatus)
                .NotEmpty().WithMessage("Order Status cannot be empty.")
                .MaximumLength(50).WithMessage("Order Status must be less than 50 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.OrderDetails)
                .SetValidator(new CreateOrderDetailDtoValidator());
        }
    }

    public class UpdateOrderDtoValidator : AbstractValidator<UpdateOrderDto>
    {
        public UpdateOrderDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.OrderDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order Date cannot be in the future.");
            RuleFor(x => x.TotalPrice)
                .GreaterThan(0).WithMessage("Total Price must be greater than 0.");
            RuleFor(x => x.OrderStatus)
                .NotEmpty().WithMessage("Order Status cannot be empty.")
                .MaximumLength(50).WithMessage("Order Status must be less than 50 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.OrderDetails)
                .SetValidator(new UpdateOrderDetailDtoValidator());
        }
    }
}