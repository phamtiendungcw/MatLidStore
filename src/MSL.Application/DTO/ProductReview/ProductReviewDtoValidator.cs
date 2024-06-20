using FluentValidation;

namespace MLS.Application.DTO.ProductReview
{
    public class ProductReviewDtoValidator : AbstractValidator<ProductReviewDto>
    {
        public ProductReviewDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
            RuleFor(x => x.ReviewText)
                .MaximumLength(1000).WithMessage("ReviewText must be less than 1000 characters.");
            RuleFor(x => x.ReviewDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("ReviewDate cannot be in the future.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class CreateProductReviewDtoValidator : AbstractValidator<CreateProductReviewDto>
    {
        public CreateProductReviewDtoValidator()
        {
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
            RuleFor(x => x.ReviewText)
                .MaximumLength(1000).WithMessage("ReviewText must be less than 1000 characters.");
            RuleFor(x => x.ReviewDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("ReviewDate cannot be in the future.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateProductReviewDtoValidator : AbstractValidator<UpdateProductReviewDto>
    {
        public UpdateProductReviewDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Rating)
                .InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
            RuleFor(x => x.ReviewText)
                .MaximumLength(1000).WithMessage("ReviewText must be less than 1000 characters.");
            RuleFor(x => x.ReviewDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("ReviewDate cannot be in the future.");
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}