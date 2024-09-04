using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Category;

namespace MLS.Application.Features.Category.Queries.GetAllCategories;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDto>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IAppLogger<GetAllCategoriesQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper, IAppLogger<GetAllCategoriesQueryHandler> logger)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<CategoryDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllAsync();
        var data = _mapper.Map<List<CategoryDto>>(categories);

        _logger.LogInformation("Categories were retrieved successfully!");
        return data;
    }
}