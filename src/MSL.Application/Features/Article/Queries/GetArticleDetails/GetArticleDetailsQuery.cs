using MediatR;
using MLS.Application.DTO.Article;

namespace MLS.Application.Features.Article.Queries.GetArticleDetails;

public record GetArticleDetailsQuery(int Id) : IRequest<ArticleDetailsDto>;