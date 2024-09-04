using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Product;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Product.Commands.CreateProductCommand;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IAppLogger<CreateProductCommandHandler> _logger;

    public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository, IAppLogger<CreateProductCommandHandler> logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new CreateProductDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Product, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in create request for {0} - {1}.", nameof(Product), request.Product);
            throw new BadRequestException("Invalid product!", validationResult);
        }

        // Convert to domain entity obj
        var productToCreate = _mapper.Map<Domain.Entities.Product>(request.Product);

        // Add to database
        await _productRepository.CreateAsync(productToCreate);

        // Return record ID
        _logger.LogInformation("Product was created successfully!");
        return productToCreate.Id;
    }
}