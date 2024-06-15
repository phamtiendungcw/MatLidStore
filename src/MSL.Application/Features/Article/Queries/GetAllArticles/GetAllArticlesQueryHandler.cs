using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;

namespace MLS.Application.Features.Article.Queries.GetAllArticles
{
    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<ArticleDto>>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public GetAllArticlesQueryHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<List<ArticleDto>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleRepository.GetAllAsync();
            var data = _mapper.Map<List<ArticleDto>>(articles);

            return data;
        }
    }
}