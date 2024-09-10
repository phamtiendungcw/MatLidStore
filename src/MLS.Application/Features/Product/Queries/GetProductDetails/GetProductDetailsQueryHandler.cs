using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Product;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.Product.Queries.GetProductDetails;

public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
{
    private readonly IAppLogger<GetProductDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetProductDetailsQueryHandler(IMapper mapper, IProductRepository productRepository, IAppLogger<GetProductDetailsQueryHandler> logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var product = await _productRepository.GetByIdAsync(request.Id, p => p.Category, p => p.ProductColors, p => p.ProductImages, p => p.ProductOptions);

        if (product is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(Product), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.Product), request.Id);
        }

        // Convert data obj to DTO obj
        var data = _mapper.Map<ProductDetailsDto>(product);

        // Return DTO obj
        _logger.LogInformation("Product details were retrieved successfully!");
        return data;
    }
}