using MediatR;
using MLS.Application.DTO.Category;

namespace MLS.Application.Features.Category.Commands.UpdateCategoryCommand
{
    public abstract class UpdateCategoryCommand : IRequest<Unit>
    {
        public UpdateCategoryDto Category { get; set; }
    }
}