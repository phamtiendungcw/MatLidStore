using MediatR;
using MLS.Application.DTO.Article;

namespace MLS.Application.Features.Article.Commands.CreateArticleCommand
{
    public abstract class CreateArticleCommand : IRequest<int>
    {
        public CreateArticleDto Article { get; set; }
    }
}