using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Queries.GetAllArticlesByAuthor;

public class GetAllArticlesByAuthorQueryHandler : IRequestHandler<GetAllArticlesByAuthorQuery, List<ArticleDto>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IAppLogger<GetAllArticlesByAuthorQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetAllArticlesByAuthorQueryHandler(IArticleRepository articleRepository, IMapper mapper, IAppLogger<GetAllArticlesByAuthorQueryHandler> logger)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<ArticleDto>> Handle(GetAllArticlesByAuthorQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArticlesByAuthorAsync(request.Author);

        if (articles is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Article), request.Author);
            throw new NotFoundException(nameof(Domain.Entities.Article), request.Author);
        }

        var data = _mapper.Map<List<ArticleDto>>(articles);

        _logger.LogInformation("Article by {0} were retrieved successfully!", request.Author);
        return data;
    }
}