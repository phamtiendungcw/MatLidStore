using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;
using MLS.Application.Exceptions;

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
            // Validate data
            var validator = new CreateCommentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Comment, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Comment", validationResult);

            var commentToCreate = _mapper.Map<Domain.Entities.Comment>(request.Comment);
            await _commentRepository.CreateAsync(commentToCreate);

            return commentToCreate.Id;
        }
    }
}