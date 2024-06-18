using FluentValidation;

namespace MLS.Application.DTO.OrderDetail
{
    public class CreateOrderDetailValidator : AbstractValidator<CreateOrderDetailDto>
    {
        public CreateOrderDetailValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit Price must be greater than 0.");
            RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }

    public class UpdateOrderDetailValidator : AbstractValidator<UpdateOrderDetailDto>
    {
        public UpdateOrderDetailValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit Price must be greater than 0.");
            RuleFor(x => x.OrderId).GreaterThan(0).WithMessage("OrderId must be greater than 0.");
        }
    }
}