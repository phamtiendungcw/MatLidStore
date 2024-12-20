﻿using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Queries.GetAllProducts;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductDto>>
{
    private readonly IAppLogger<GetAllProductsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductRepository _productRepository;

    public GetAllProductsQueryHandler(IMapper mapper, IProductRepository productRepository, IAppLogger<GetAllProductsQueryHandler> logger)
    {
        _mapper = mapper;
        _productRepository = productRepository;
        _logger = logger;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        // Query the database
        var products = await _productRepository.GetAllAsync();

        // Convert data obj to DTO obj
        var data = _mapper.Map<List<ProductDto>>(products);

        // Return list of DTO obj
        _logger.LogInformation("Products were retrieved successfully!");
        return data;
    }
}