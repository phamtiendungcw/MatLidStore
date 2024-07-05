using MediatR;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Queries.GetAllProducts;

public record GetAllProductsQuery : IRequest<List<ProductDto>>;