using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Product;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Product.Commands.UpdateProductCommand;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        // Validate data
        var validator = new UpdateProductDtoValidator();
        var validationResult = await validator.ValidateAsync(request.Product, cancellationToken);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Product", validationResult);

        // Convert to domain entity obj
        var productToUpdate = _mapper.Map<Domain.Entities.Product>(request.Product);

        // Add to database
        await _productRepository.UpdateAsync(productToUpdate);

        // Return Unit value
        return Unit.Value;
    }
}