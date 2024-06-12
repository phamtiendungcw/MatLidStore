using FluentValidation;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Order.Commands.CreateOrderCommand
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandValidator(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");

            RuleFor(x => x.OrderDate)
                .NotEmpty().WithMessage("Order date is required.");

            RuleFor(x => x.TotalAmount)
                .GreaterThan(0).WithMessage("Total amount must be greater than zero.");

            RuleFor(x => x.ShippingAddress)
                .NotEmpty().WithMessage("Shipping address is required.");
        }
    }
}