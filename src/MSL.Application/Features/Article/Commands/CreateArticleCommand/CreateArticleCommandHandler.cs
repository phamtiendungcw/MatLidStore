using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Commands.CreateArticleCommand
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;
        private readonly IAppLogger<CreateArticleCommandHandler> _logger;

        public CreateArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository, IAppLogger<CreateArticleCommandHandler> logger)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
            _logger = logger;
        }

        public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateArticleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Article);

            if (!validationResult.IsValid)
            {
                _logger.LogInformation($"Validation error request for {0} - {1}", nameof(Domain.Entities.Article), request.Article);
                throw new BadRequestException("Invalid Article", validationResult);
            }

            var articleToCreate = _mapper.Map<Domain.Entities.Article>(request.Article);
            await _articleRepository.CreateAsync(articleToCreate);

            return articleToCreate.Id;
        }
    }
}