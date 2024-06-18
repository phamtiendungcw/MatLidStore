using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Comment.Commands.CreateCommentCommand
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToCreate = _mapper.Map<Domain.Entities.Comment>(request.Comment);
            await _commentRepository.CreateAsync(commentToCreate);

            return commentToCreate.Id;
        }
    }
}