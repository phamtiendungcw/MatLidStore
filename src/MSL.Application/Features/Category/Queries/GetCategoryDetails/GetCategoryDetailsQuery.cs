using MediatR;
using MLS.Application.DTO.Category;

namespace MLS.Application.Features.Category.Queries.GetCategoryDetails
{
    public record GetCategoryDetailsQuery(int Id) : IRequest<CategoryDetailsDto>;
}