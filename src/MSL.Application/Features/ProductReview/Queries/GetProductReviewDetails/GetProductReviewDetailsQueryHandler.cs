using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.ProductReview;
using MLS.Application.Exceptions;

namespace MLS.Application.Features.ProductReview.Queries.GetProductReviewDetails;

public class GetProductReviewDetailsQueryHandler : IRequestHandler<GetProductReviewDetailsQuery, ProductReviewDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IProductReviewRepository _productReviewRepository;

    public GetProductReviewDetailsQueryHandler(IProductReviewRepository productReviewRepository, IMapper mapper)
    {
        _productReviewRepository = productReviewRepository;
        _mapper = mapper;
    }

    public async Task<ProductReviewDetailsDto> Handle(GetProductReviewDetailsQuery request, CancellationToken cancellationToken)
    {
        var productReview = await _productReviewRepository.GetByIdAsync(request.Id);

        if (productReview is null)
            throw new NotFoundException(nameof(Domain.Entities.ProductReview), request.Id);

        var data = _mapper.Map<ProductReviewDetailsDto>(productReview);

        return data;
    }
}