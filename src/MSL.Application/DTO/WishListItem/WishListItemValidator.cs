using FluentValidation;

namespace MLS.Application.DTO.WishListItem
{
    public class CreateWishListItemValidator : AbstractValidator<CreateWishListItemDto>
    {
        public CreateWishListItemValidator()
        {
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.WishListId).GreaterThan(0).WithMessage("WishListId must be greater than 0.");
        }
    }

    public class UpdateWishListItemValidator : AbstractValidator<UpdateWishListItemDto>
    {
        public UpdateWishListItemValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.WishListId).GreaterThan(0).WithMessage("WishListId must be greater than 0.");
        }
    }
}