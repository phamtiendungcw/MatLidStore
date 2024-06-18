using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Comment.Queries.GetCommentDetails
{
    public class GetCommentDetailsQueryHandler : IRequestHandler<GetCommentDetailsQuery, CommentDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public GetCommentDetailsQueryHandler(IMapper mapper, ICommentRepository commentRepository)
        {
            _mapper = mapper;
            _commentRepository = commentRepository;
        }

        public async Task<CommentDetailsDto> Handle(GetCommentDetailsQuery request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetByIdAsync(request.Id);

            if (comment is null)
                throw new NotFoundException(nameof(Domain.Entities.Comment), request.Id);

            var data = _mapper.Map<CommentDetailsDto>(comment);

            return data;
        }
    }
}