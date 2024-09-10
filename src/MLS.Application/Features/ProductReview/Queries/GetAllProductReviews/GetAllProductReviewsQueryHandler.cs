using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Logging;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.Features.ProductReview.Queries.GetAllProductReviews;

public class GetAllProductReviewsQueryHandler : IRequestHandler<GetAllProductReviewsQuery, List<ProductReviewDto>>
{
    private readonly IAppLogger<GetAllProductReviewsQueryHandler> _logger;
    private readonly IMapper _mapper;
    private readonly IProductReviewRepository _productReviewRepository;

    public GetAllProductReviewsQueryHandler(IProductReviewRepository productReviewRepository, IMapper mapper, IAppLogger<GetAllProductReviewsQueryHandler> logger)
    {
        _productReviewRepository = productReviewRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<List<ProductReviewDto>> Handle(GetAllProductReviewsQuery request,
        CancellationToken cancellationToken)
    {
        var productReviews = await _productReviewRepository.GetAllAsync();
        var data = _mapper.Map<List<ProductReviewDto>>(productReviews);

        _logger.LogInformation("Product reviews were retrieved successfully!");
        return data;
    }
}