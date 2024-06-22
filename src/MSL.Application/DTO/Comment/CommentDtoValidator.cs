using FluentValidation;

namespace MLS.Application.DTO.Comment
{
    public class CommentDtoValidator : AbstractValidator<CommentDto>
    {
        public CommentDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty.");
            RuleFor(x => x.Author)
                .MaximumLength(100).WithMessage("Author must be less than 100 characters.");
            RuleFor(x => x.Timestamp)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Timestamp cannot be in the future.");
            RuleFor(x => x.ArticleId)
                .GreaterThan(0).WithMessage("ArticleId must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentDtoValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Content cannot be empty.");
            RuleFor(x => x.Author)
                .MaximumLength(100).WithMessage("Author must be less than 100 characters.");
            RuleFor(x => x.Timestamp)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Timestamp cannot be in the future.");
            RuleFor(x => x.ArticleId)
                .GreaterThan(0).WithMessage("ArticleId must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }

    public class UpdateCommentDtoValidator : AbstractValidator<UpdateCommentDto>
    {
        public UpdateCommentDtoValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Content)
                .NotEmpty().When(x => x.Content != null).WithMessage("Content cannot be empty.");
            RuleFor(x => x.Author)
                .MaximumLength(100).WithMessage("Author must be less than 100 characters.");
            RuleFor(x => x.Timestamp)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Timestamp cannot be in the future.");
            RuleFor(x => x.ArticleId)
                .GreaterThan(0).WithMessage("ArticleId must be greater than 0.");
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }
    }
}