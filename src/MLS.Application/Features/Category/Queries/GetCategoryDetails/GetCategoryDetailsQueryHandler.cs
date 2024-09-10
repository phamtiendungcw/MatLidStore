using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Category;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Category.Queries.GetCategoryDetails;

public class GetCategoryDetailsQueryHandler : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAppLogger<GetCategoryDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetCategoryDetailsQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, IAppLogger<GetCategoryDetailsQueryHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<CategoryDetailsDto> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);

        if (category is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Category), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Category), request.Id);
        }

        var data = _mapper.Map<CategoryDetailsDto>(category);

        _logger.LogInformation("Category was retrieved successfully!");
        return data;
    }
}