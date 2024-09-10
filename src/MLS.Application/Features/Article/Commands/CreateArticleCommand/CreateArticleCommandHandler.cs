using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Commands.CreateArticleCommand;

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IAppLogger<CreateArticleCommandHandler> _logger;
    private readonly IMapper _mapper;

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
        var validationResult = await validator.ValidateAsync(request.Article, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(Article), request.Article);
            throw new BadRequestException("Invalid article!", validationResult);
        }

        var articleToCreate = _mapper.Map<Domain.Entities.Article>(request.Article);
        await _articleRepository.CreateAsync(articleToCreate);

        _logger.LogInformation("Article was created successfully!");
        return articleToCreate.Id;
    }
}