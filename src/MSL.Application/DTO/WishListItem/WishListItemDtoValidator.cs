using FluentValidation;

namespace MLS.Application.DTO.WishListItem;

public class WishListItemDtoValidator : AbstractValidator<WishListItemDto>
{
    public WishListItemDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(x => x.WishListId)
            .GreaterThan(0).WithMessage("WishListId must be greater than 0.");
    }
}

public class CreateWishListItemDtoValidator : AbstractValidator<CreateWishListItemDto>
{
    public CreateWishListItemDtoValidator()
    {
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(x => x.WishListId)
            .GreaterThan(0).WithMessage("WishListId must be greater than 0.");
    }
}

public class UpdateWishListItemDtoValidator : AbstractValidator<UpdateWishListItemDto>
{
    public UpdateWishListItemDtoValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.ProductId)
            .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
        RuleFor(x => x.WishListId)
            .GreaterThan(0).WithMessage("WishListId must be greater than 0.");
    }
}