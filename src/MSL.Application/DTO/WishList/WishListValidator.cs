using FluentValidation;

namespace MLS.Application.DTO.WishList
{
    public class CreateWishListValidator : AbstractValidator<CreateWishListDto>
    {
        public CreateWishListValidator()
        {
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateWishListValidator : AbstractValidator<UpdateWishListDto>
    {
        public UpdateWishListValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}