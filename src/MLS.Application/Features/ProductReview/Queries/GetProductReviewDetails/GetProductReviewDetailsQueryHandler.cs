using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Queries.GetProductReviewDetails;

public class
    GetProductReviewDetailsQueryHandler : IRequestHandler<GetProductReviewDetailsQuery, ProductReviewDetailsDto>
{
    private readonly IAppLogger<GetProductReviewDetailsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductReviewRepository _productReviewRepository;

    public GetProductReviewDetailsQueryHandler(IProductReviewRepository productReviewRepository, IMapper mapper, IAppLogger<GetProductReviewDetailsQueryHandler> logger)
    {
        _productReviewRepository = productReviewRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<ProductReviewDetailsDto> Handle(GetProductReviewDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var productReview = await _productReviewRepository.GetByIdAsync(request.Id);

        if (productReview is null)
        {
            _logger.LogWarning("Object {0} with id value equal to {1} was not found in the retrieve request.", nameof(ProductReview), request.Id);
            throw new NotFoundException(nameof(Domain.Entities.ProductReview), request.Id);
        }

        var data = _mapper.Map<ProductReviewDetailsDto>(productReview);

        _logger.LogInformation("Product review was retrieved successfully!");
        return data;
    }
}