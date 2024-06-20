using FluentValidation;
using MLS.Application.DTO.ShoppingCartItem;

namespace MLS.Application.DTO.ShoppingCart
{
    public class ShoppingCartDtoValidator : AbstractValidator<ShoppingCartDto>
    {
        public ShoppingCartDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.ShoppingCartItems)
                .SetValidator(new ShoppingCartItemDtoValidator());
        }
    }

    public class CreateShoppingCartDtoValidator : AbstractValidator<CreateShoppingCartDto>
    {
        public CreateShoppingCartDtoValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.ShoppingCartItems)
                .SetValidator(new CreateShoppingCartItemDtoValidator());
        }
    }

    public class UpdateShoppingCartDtoValidator : AbstractValidator<UpdateShoppingCartDto>
    {
        public UpdateShoppingCartDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.ShoppingCartItems)
                .SetValidator(new UpdateShoppingCartItemDtoValidator());
        }
    }
}