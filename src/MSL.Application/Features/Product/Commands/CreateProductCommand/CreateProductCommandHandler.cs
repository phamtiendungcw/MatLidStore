using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Product.Commands.CreateProductCommand
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Validate data
            var validator = new CreateProductCommandValidator(_productRepository);
            var validationResult = await validator.ValidateAsync(request.Product);

            if (!validationResult.IsValid)
                throw new BadRequestException("Invalid Product", validationResult);

            // Convert to domain entity obj
            var productToCreate = _mapper.Map<Domain.Entities.Product>(request.Product);

            // Add to database
            await _productRepository.CreateAsync(productToCreate);

            // Return record ID
            return productToCreate.Id;
        }
    }
}