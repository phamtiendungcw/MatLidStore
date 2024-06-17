using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;

namespace MLS.Application.Features.ProductReview.Commands.CreateProductReviewCommand
{
    public class CreateProductReviewCommandHandler : IRequestHandler<CreateProductReviewCommand, int>
    {
        private readonly IProductReviewRepository _productReviewRepository;
        private readonly IMapper _mapper;

        public CreateProductReviewCommandHandler(IProductReviewRepository productReviewRepository, IMapper mapper)
        {
            _productReviewRepository = productReviewRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductReviewCommand request, CancellationToken cancellationToken)
        {
            var productReviewToCreate = _mapper.Map<Domain.Entities.ProductReview>(request.ProductReview);
            await _productReviewRepository.CreateAsync(productReviewToCreate);

            return productReviewToCreate.Id;
        }
    }
}