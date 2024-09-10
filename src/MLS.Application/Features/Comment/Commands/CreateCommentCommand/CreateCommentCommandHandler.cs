using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Comment;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Comment.Commands.CreateCommentCommand;

public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IAppLogger<CreateCommentCommandHandler> _logger;
    private readonly IMapper _mapper;

    public CreateCommentCommandHandler(IMapper mapper, ICommentRepository commentRepository, IAppLogger<CreateCommentCommandHandler> logger)
    {
        _mapper = mapper;
        _commentRepository = commentRepository;
        _logger = logger;
    }

    public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateCommentDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Comment, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validator errors in create for {0} - {1}.", nameof(Comment), request.Comment);
            throw new BadRequestException("Invalid comment!", validationResult);
        }

        var commentToCreate = _mapper.Map<Domain.Entities.Comment>(request.Comment);
        await _commentRepository.CreateAsync(commentToCreate);

        _logger.LogInformation("Comment was created successfully!");
        return commentToCreate.Id;
    }
}