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
        }
    }
}