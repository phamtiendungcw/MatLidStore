using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Category;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Category.Commands.UpdateCategoryCommand;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAppLogger<UpdateCategoryCommandHandler> _logger;
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IAppLogger<UpdateCategoryCommandHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateCategoryDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Category, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(Category), request.Category);
            throw new BadRequestException("Invalid category!", validationResult);
        }

        var categoryToUpdate = _mapper.Map<Domain.Entities.Category>(request.Category);
        await _categoryRepository.UpdateAsync(categoryToUpdate);

        _logger.LogInformation("Category was updated successfully!");
        return Unit.Value;
    }
}