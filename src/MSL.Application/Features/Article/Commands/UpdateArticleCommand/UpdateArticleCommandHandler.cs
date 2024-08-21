using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Commands.UpdateArticleCommand;

public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Unit>
{
    private readonly IArticleRepository _articleRepository;
    private readonly IAppLogger<UpdateArticleCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository,
        IAppLogger<UpdateArticleCommandHandler> logger)
    {
        _mapper = mapper;
        _articleRepository = articleRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateArticleDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Article, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning($"Validation errors in update request for {0} - {1}", nameof(Domain.Entities.Article),
                request.Article.Id);
            throw new BadRequestException("Invalid Article", validationResult);
        }

        var articleToUpdate = _mapper.Map<Domain.Entities.Article>(request.Article);
        await _articleRepository.UpdateAsync(articleToUpdate);

        return Unit.Value;
    }
}