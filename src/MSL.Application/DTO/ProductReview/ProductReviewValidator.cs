using FluentValidation;

namespace MLS.Application.DTO.ProductReview
{
    public class CreateProductReviewValidator : AbstractValidator<CreateProductReviewDto>
    {
        public CreateProductReviewValidator()
        {
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
            RuleFor(x => x.ReviewText).NotEmpty().WithMessage("ReviewText is required.");
            RuleFor(x => x.ReviewDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("ReviewDate cannot be in the future.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than zero.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than zero.");
        }
    }

    public class UpdateProductReviewValidator : AbstractValidator<UpdateProductReviewDto>
    {
        public UpdateProductReviewValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("ProductReviewId is required.");
            RuleFor(x => x.Rating).InclusiveBetween(1, 5).WithMessage("Rating must be between 1 and 5.");
            RuleFor(x => x.ReviewText).NotEmpty().WithMessage("ReviewText is required.");
            RuleFor(x => x.ReviewDate).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("ReviewDate cannot be in the future.");
            RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("ProductId must be greater than zero.");
            RuleFor(x => x.UserId).GreaterThan(0).WithMessage("UserId must be greater than zero.");
        }
    }
}