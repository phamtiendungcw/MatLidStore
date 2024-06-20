using FluentValidation;
using MLS.Application.DTO.Comment;

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
            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.Comments)
                .SetValidator(new CommentDtoValidator());
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
            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.Comments)
                .SetValidator(new CreateCommentDtoValidator());
        }
    }

    public class UpdateArticleDtoValidator : AbstractValidator<UpdateArticleDto>
    {
        public UpdateArticleDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
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
            RuleFor(x => x.AuthorId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
            RuleForEach(x => x.Comments)
                .SetValidator(new UpdateCommentDtoValidator());
        }
    }
}