using MediatR;
using MLS.Application.DTO.Category;

namespace MLS.Application.Features.Category.Commands.CreateCategoryCommand
{
    public abstract class CreateCategoryCommand : IRequest<int>
    {
        public CreateCategoryDto Category { get; set; } = new();
    }
}