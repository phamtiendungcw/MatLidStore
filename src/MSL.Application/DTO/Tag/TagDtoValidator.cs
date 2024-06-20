using FluentValidation;
using MLS.Application.DTO.Article;
using MLS.Application.DTO.ProductTag;

namespace MLS.Application.DTO.Tag
{
    public class TagDtoValidator : AbstractValidator<TagDto>
    {
        public TagDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleForEach(x => x.ProductTags)
                .SetValidator(new ProductTagDtoValidator());
            RuleForEach(x => x.Articles)
                .SetValidator(new ArticleDtoValidator());
        }
    }

    public class CreateTagDtoValidator : AbstractValidator<CreateTagDto>
    {
        public CreateTagDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleForEach(x => x.ProductTags)
                .SetValidator(new CreateProductTagDtoValidator());
            RuleForEach(x => x.Articles).SetValidator(new CreateArticleDtoValidator());
        }
    }

    public class UpdateTagDtoValidator : AbstractValidator<UpdateTagDto>
    {
        public UpdateTagDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name cannot be empty.")
                .MaximumLength(100).WithMessage("Name must be less than 100 characters.");
            RuleForEach(x => x.ProductTags)
                .SetValidator(new UpdateProductTagDtoValidator());
            RuleForEach(x => x.Articles)
                .SetValidator(new UpdateArticleDtoValidator());
        }
    }
}