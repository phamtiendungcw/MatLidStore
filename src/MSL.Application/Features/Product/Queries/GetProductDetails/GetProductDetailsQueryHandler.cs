using AutoMapper;
using MediatR;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, ProductDetailsDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public GetProductDetailsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ProductDetailsDto> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
        {
            // Query the database
            var product = await _productRepository.GetByIdAsync(request.Id);

            // Convert data obj to DTO obj
            var data = _mapper.Map<ProductDetailsDto>(product);

            // Return DTO obj
            return data;
        }
    }
}