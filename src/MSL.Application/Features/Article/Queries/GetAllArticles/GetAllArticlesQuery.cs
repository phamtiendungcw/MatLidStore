using MediatR;
using MLS.Application.DTO.Article;

namespace MLS.Application.Features.Article.Queries.GetAllArticles
{
    public record GetAllArticlesQuery : IRequest<List<ArticleDto>>;
}