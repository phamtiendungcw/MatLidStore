using MediatR;
using MLS.Application.DTO.Article;

namespace MLS.Application.Features.Article.Queries.GetAllArticlesByAuthor
{
    public record GetAllArticlesByAuthorQuery(string Author) : IRequest<List<ArticleDto>>;
}