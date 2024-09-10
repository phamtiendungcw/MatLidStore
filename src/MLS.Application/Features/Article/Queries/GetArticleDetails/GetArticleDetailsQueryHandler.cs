using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Queries.GetArticleDetails;

public class GetArticleDetailsQueryHandler : IRequestHandler<GetArticleDetailsQuery, ArticleDetailsDto>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IAppLogger<GetArticleDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetArticleDetailsQueryHandler(IMapper mapper, IArticleRepository articleRepository,
        IAppLogger<GetArticleDetailsQueryHandler> logger)
    {
        _mapper = mapper;
        _articleRepository = articleRepository;
        _logger = logger;
    }

    public async Task<ArticleDetailsDto> Handle(GetArticleDetailsQuery request, CancellationToken cancellationToken)
    {
        var article = await _articleRepository.GetByIdAsync(request.Id, i => i.Comments);

        if (article is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Article), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Article), request.Id);
        }

        var data = _mapper.Map<ArticleDetailsDto>(article);

        _logger.LogInformation("Article details were retrieved successfully!");
        return data;
    }
}