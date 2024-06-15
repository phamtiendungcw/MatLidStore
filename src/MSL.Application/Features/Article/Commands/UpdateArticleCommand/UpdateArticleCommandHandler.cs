using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

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
            var articleToUpdate = _mapper.Map<Domain.Entities.Article>(request.Article);
            await _articleRepository.UpdateAsync(articleToUpdate);

            return Unit.Value;
        }
    }
}