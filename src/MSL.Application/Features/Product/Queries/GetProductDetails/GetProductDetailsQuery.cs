using MediatR;
using MLS.Application.DTO.Product;

namespace MLS.Application.Features.Product.Queries.GetProductDetails;

public record GetProductDetailsQuery(int Id) : IRequest<ProductDetailsDto>;