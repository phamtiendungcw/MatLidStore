using MediatR;
using MLS.Application.DTO.Category;

namespace MLS.Application.Features.Category.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public UpdateCategoryDto Category { get; set; } = null!;
    }
}