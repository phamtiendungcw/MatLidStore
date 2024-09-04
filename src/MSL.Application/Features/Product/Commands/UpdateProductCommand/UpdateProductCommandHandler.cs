using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Product;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Product.Commands.UpdateProductCommand;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;
    private readonly IAppLogger<UpdateProductCommandHandler> _logger;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository, IAppLogger<UpdateProductCommandHandler> logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateProductDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Product, cancellationToken);

        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation errors in update request for {0} - {1}.", nameof(Product), request.Product);
            throw new BadRequestException("Invalid product!", validationResult);
        }

        // Convert to domain entity obj
        var productToUpdate = _mapper.Map<Domain.Entities.Product>(request.Product);

        // Add to database
        await _productRepository.UpdateAsync(productToUpdate);

        // Return Unit value
        _logger.LogInformation("Product was updated successfully!");
        return Unit.Value;
    }
}