using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Article;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Article.Commands.UpdateArticleCommand
{
    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public UpdateArticleCommandHandler(IMapper mapper, IArticleRepository articleRepository)
        {
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task<Unit> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new UpdateArticleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Article);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Article", validationResult);

            var articleToUpdate = _mapper.Map<Domain.Entities.Article>(request.Article);
            await _articleRepository.UpdateAsync(articleToUpdate);

            return Unit.Value;
        }
    }
}