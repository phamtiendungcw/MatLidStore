using FluentValidation;
using MLS.Application.DTO.WishListItem;

namespace MLS.Application.DTO.WishList
{
    public class WishListDtoValidator : AbstractValidator<WishListDto>
    {
        public WishListDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.WishListItems)
                .SetValidator(new WishListItemDtoValidator());
        }
    }

    public class CreateWishListDtoValidator : AbstractValidator<CreateWishListDto>
    {
        public CreateWishListDtoValidator()
        {
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.WishListItems)
                .SetValidator(new CreateWishListItemDtoValidator());
        }
    }

    public class UpdateWishListDtoValidator : AbstractValidator<UpdateWishListDto>
    {
        public UpdateWishListDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.WishListItems)
                .SetValidator(new UpdateWishListItemDtoValidator());
        }
    }
}