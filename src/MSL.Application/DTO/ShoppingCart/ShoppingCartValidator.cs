using FluentValidation;

namespace MLS.Application.DTO.ShoppingCart
{
    public class CreateShoppingCartValidator : AbstractValidator<CreateShoppingCartDto>
    {
        public CreateShoppingCartValidator()
        {
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateShoppingCartValidator : AbstractValidator<UpdateShoppingCartDto>
    {
        public UpdateShoppingCartValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}