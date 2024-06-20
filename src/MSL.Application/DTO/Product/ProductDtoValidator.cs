using FluentValidation;
using MLS.Application.DTO.OrderDetail;
using MLS.Application.DTO.ProductColor;
using MLS.Application.DTO.ProductImage;
using MLS.Application.DTO.ProductOption;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.DTO.Product
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must be less than 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
            RuleForEach(x => x.ProductOptions)
                .SetValidator(new ProductOptionDtoValidator());
            RuleForEach(x => x.ProductColors)
                .SetValidator(new ProductColorDtoValidator());
            RuleForEach(x => x.ProductImages)
                .SetValidator(new ProductImageDtoValidator());
            RuleForEach(x => x.ProductReviews)
                .SetValidator(new ProductReviewDtoValidator());
            RuleForEach(x => x.OrderDetails)
                .SetValidator(new OrderDetailDtoValidator());
        }
    }

    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must be less than 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
            RuleForEach(x => x.ProductOptions)
                .SetValidator(new CreateProductOptionDtoValidator());
            RuleForEach(x => x.ProductColors)
                .SetValidator(new CreateProductColorDtoValidator());
            RuleForEach(x => x.ProductImages)
                .SetValidator(new CreateProductImageDtoValidator());
            RuleForEach(x => x.ProductReviews)
                .SetValidator(new CreateProductReviewDtoValidator());
            RuleForEach(x => x.OrderDetails)
                .SetValidator(new CreateOrderDetailDtoValidator());
        }
    }

    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must be less than 500 characters.");
            RuleFor(x => x.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.CategoryId)
                .GreaterThan(0).WithMessage("CategoryId must be greater than 0.");
            RuleForEach(x => x.ProductOptions)
                .SetValidator(new UpdateProductOptionDtoValidator());
            RuleForEach(x => x.ProductColors)
                .SetValidator(new UpdateProductColorDtoValidator());
            RuleForEach(x => x.ProductImages)
                .SetValidator(new UpdateProductImageDtoValidator());
            RuleForEach(x => x.ProductReviews)
                .SetValidator(new UpdateProductReviewDtoValidator());
            RuleForEach(x => x.OrderDetails)
                .SetValidator(new UpdateOrderDetailDtoValidator());
        }
    }
}