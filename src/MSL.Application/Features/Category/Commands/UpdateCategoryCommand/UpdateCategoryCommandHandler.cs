using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Category;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Category.Commands.UpdateCategoryCommand
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new UpdateCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.Category, cancellationToken);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Category", validationResult);

            var categoryToUpdate = _mapper.Map<Domain.Entities.Category>(request.Category);
            await _categoryRepository.UpdateAsync(categoryToUpdate);

            return Unit.Value;
        }
    }
}