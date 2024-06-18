using MediatR;
using MLS.Application.DTO.Category;

namespace MLS.Application.Features.Category.Queries.GetAllCategories
{
    public abstract record GetAllCategoriesQuery : IRequest<List<CategoryDto>>;
}