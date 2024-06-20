using FluentValidation;
using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;
using MLS.Application.DTO.ProductReview;
using MLS.Application.DTO.WishList;

namespace MLS.Application.DTO.User
{
    public class UserDtoValidator : AbstractValidator<UserDto>
    {
        public UserDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MaximumLength(50).WithMessage("Username must be less than 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("PasswordHash cannot be empty.");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.")
                .MaximumLength(50).WithMessage("FirstName must be less than 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.")
                .MaximumLength(50).WithMessage("LastName must be less than 50 characters.");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone cannot be empty.")
                .MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
            RuleForEach(x => x.Orders)
                .SetValidator(new OrderDtoValidator());
            RuleForEach(x => x.ProductReviews)
                .SetValidator(new ProductReviewDtoValidator());
            RuleForEach(x => x.WishLists)
                .SetValidator(new WishListDtoValidator());
            RuleForEach(x => x.Comments)
                .SetValidator(new CommentDtoValidator());
            RuleForEach(x => x.Notifications)
                .SetValidator(new NotificationDtoValidator());
        }
    }

    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MaximumLength(50).WithMessage("Username must be less than 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("PasswordHash cannot be empty.");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.")
                .MaximumLength(50).WithMessage("FirstName must be less than 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.")
                .MaximumLength(50).WithMessage("LastName must be less than 50 characters.");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone cannot be empty.")
                .MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
            RuleForEach(x => x.Orders)
                .SetValidator(new CreateOrderDtoValidator());
            RuleForEach(x => x.ProductReviews)
                .SetValidator(new CreateProductReviewDtoValidator());
            RuleForEach(x => x.WishLists)
                .SetValidator(new CreateWishListDtoValidator());
            RuleForEach(x => x.Comments)
                .SetValidator(new CreateCommentDtoValidator());
            RuleForEach(x => x.Notifications)
                .SetValidator(new CreateNotificationDtoValidator());
        }
    }

    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username cannot be empty.")
                .MaximumLength(50).WithMessage("Username must be less than 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.PasswordHash)
                .NotEmpty().WithMessage("PasswordHash cannot be empty.");
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName cannot be empty.")
                .MaximumLength(50).WithMessage("FirstName must be less than 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName cannot be empty.")
                .MaximumLength(50).WithMessage("LastName must be less than 50 characters.");
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone cannot be empty.")
                .MaximumLength(20).WithMessage("Phone must be less than 20 characters.");
            RuleForEach(x => x.Orders)
                .SetValidator(new UpdateOrderDtoValidator());
            RuleForEach(x => x.ProductReviews)
                .SetValidator(new UpdateProductReviewDtoValidator());
            RuleForEach(x => x.WishLists)
                .SetValidator(new UpdateWishListDtoValidator());
            RuleForEach(x => x.Comments)
                .SetValidator(new UpdateCommentDtoValidator());
            RuleForEach(x => x.Notifications)
                .SetValidator(new UpdateNotificationDtoValidator());
        }
    }
}