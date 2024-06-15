using MediatR;
using MLS.Application.DTO.Article;

namespace MLS.Application.Features.Article.Commands.UpdateArticleCommand
{
    public abstract class UpdateArticleCommand : IRequest<Unit>
    {
        public UpdateArticleDto Article { get; set; }
    }
}