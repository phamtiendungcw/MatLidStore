﻿using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Queries.GetArticleDetails
{
    public class GetArticleDetailsQueryHandler : IRequestHandler<GetArticleDetailsQuery, ArticleDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public GetArticleDetailsQueryHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDetailsDto> Handle(GetArticleDetailsQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleRepository.GetByIdAsync(request.Id);

            if (article is null)
                throw new NotFoundException(nameof(Domain.Entities.Article), request.Id);

            var data = _mapper.Map<ArticleDetailsDto>(article);

            return data;
        }
    }
}