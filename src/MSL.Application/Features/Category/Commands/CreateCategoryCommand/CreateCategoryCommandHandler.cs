using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Category;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAppLogger<CreateCategoryCommandHandler> _logger;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper, IAppLogger<CreateCategoryCommandHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateCategoryDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Category, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(Category), request.Category);
            throw new BadRequestException("Invalid category!", validationResult);
        }

        var categoryToCreate = _mapper.Map<Domain.Entities.Category>(request.Category);
        await _categoryRepository.CreateAsync(categoryToCreate);

        _logger.LogInformation("Category was created successfully!");
        return categoryToCreate.Id;
    }
}