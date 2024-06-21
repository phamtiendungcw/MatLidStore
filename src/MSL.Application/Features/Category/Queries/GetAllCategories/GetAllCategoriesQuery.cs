using MediatR;
using MLS.Application.DTO.Category;

namespace MLS.Application.Features.Category.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;
}