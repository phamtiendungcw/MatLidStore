using FluentValidation;

namespace MLS.Application.DTO.Article
{
    public class ArticleDtoValidator : AbstractValidator<ArticleDto>
    {
        public ArticleDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(200).WithMessage("Title must be less than 200 characters.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty.");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author cannot be empty.")
                .MaximumLength(100).WithMessage("Author must be less than 100 characters.");
            RuleFor(x => x.PublicationDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Publication Date cannot be in the future.");
        }
    }

    public class CreateArticleDtoValidator : AbstractValidator<CreateArticleDto>
    {
        public CreateArticleDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(200).WithMessage("Title cannot be empty and must be less than 200 characters.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty.");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author cannot be empty.")
                .MaximumLength(100).WithMessage("Author cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.PublicationDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Publication Date cannot be in the future.");
        }
    }

    public class UpdateArticleDtoValidator : AbstractValidator<UpdateArticleDto>
    {
        public UpdateArticleDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Title)
                .NotEmpty().When(x => x.Title != null).WithMessage("Title cannot be empty.")
                .MaximumLength(200).WithMessage("Title cannot be empty and must be less than 200 characters.");
            RuleFor(x => x.Content)
                .NotEmpty().When(x => x.Content != null).WithMessage("Content cannot be empty.");
            RuleFor(x => x.Author)
                .NotEmpty().When(x => x.Author != null).WithMessage("Author cannot be empty.")
                .MaximumLength(100).WithMessage("Author cannot be empty and must be less than 100 characters.");
            RuleFor(x => x.PublicationDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Publication Date cannot be in the future.");
        }
    }
}