using FluentValidation;

namespace MLS.Application.DTO.ShoppingCartItem
{
    public class CreateShoppingCartItemValidator : AbstractValidator<CreateShoppingCartItemDto>
    {
        public CreateShoppingCartItemValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.ShoppingCartId).GreaterThan(0).WithMessage("ShoppingCartId must be greater than 0.");
        }
    }

    public class UpdateShoppingCartItemValidator : AbstractValidator<UpdateShoppingCartItemDto>
    {
        public UpdateShoppingCartItemValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.ShoppingCartId).GreaterThan(0).WithMessage("ShoppingCartId must be greater than 0.");
        }
    }
}