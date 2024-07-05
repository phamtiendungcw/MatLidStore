using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Queries.GetAllArticlesByAuthor;

public class GetAllArticlesByAuthorQueryHandler : IRequestHandler<GetAllArticlesByAuthorQuery, List<ArticleDto>>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IMapper _mapper;

    public GetAllArticlesByAuthorQueryHandler(IArticleRepository articleRepository, IMapper mapper)
    {
        _articleRepository = articleRepository;
        _mapper = mapper;
    }

    public async Task<List<ArticleDto>> Handle(GetAllArticlesByAuthorQuery request, CancellationToken cancellationToken)
    {
        var articles = await _articleRepository.GetArticlesByAuthorAsync(request.Author);

        if (articles is null)
            throw new NotFoundException(nameof(Domain.Entities.Article), request.Author);

        var data = _mapper.Map<List<ArticleDto>>(articles);

        return data;
    }
}