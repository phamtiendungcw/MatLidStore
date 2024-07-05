using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Category;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Category.Commands.CreateCategoryCommand;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateCategoryDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Category, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Category", validationResult);

        var categoryToCreate = _mapper.Map<Domain.Entities.Category>(request.Category);
        await _categoryRepository.CreateAsync(categoryToCreate);

        return categoryToCreate.Id;
    }
}