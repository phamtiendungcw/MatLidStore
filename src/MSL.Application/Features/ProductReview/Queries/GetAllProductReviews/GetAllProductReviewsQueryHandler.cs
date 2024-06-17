using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;

namespace MLS.Application.Features.ProductReview.Queries.GetAllProductReviews
{
    public class GetAllProductReviewsQueryHandler : IRequestHandler<GetAllProductReviewsQuery, List<ProductReviewDto>>
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IMapper _mapper;

        public GetAllProductReviewsQueryHandler(IProductReviewRepository productReviewRepository, IMapper mapper)
        {
            _productReviewRepository = productReviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductReviewDto>> Handle(GetAllProductReviewsQuery request, CancellationToken cancellationToken)
        {
            var productReviews = await _productReviewRepository.GetAllAsync();
            var data = _mapper.Map<List<ProductReviewDto>>(productReviews);

            return data;
        }
    }
}