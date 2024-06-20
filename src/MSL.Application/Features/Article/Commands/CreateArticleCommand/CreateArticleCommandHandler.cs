using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Commands.CreateArticleCommand
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public CreateArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateArticleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Article);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Article", validationResult);

            var articleToCreate = _mapper.Map<Domain.Entities.Article>(request.Article);
            await _articleRepository.CreateAsync(articleToCreate);

            return articleToCreate.Id;
        }
    }
}