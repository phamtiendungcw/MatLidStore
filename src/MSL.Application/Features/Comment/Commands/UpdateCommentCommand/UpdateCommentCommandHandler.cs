using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.Comment.Commands.UpdateCommentCommand
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public UpdateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            var commentToUpdate = _mapper.Map<Domain.Entities.Comment>(request.Comment);
            await _commentRepository.UpdateAsync(commentToUpdate);

            return Unit.Value;
        }
    }
}