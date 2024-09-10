using MediatR;
using MLS.Application.DTO.ShoppingCart;

namespace MLS.Application.Features.ShoppingCart.Queries.GetAllShoppingCarts;

public record GetAllShoppingCartsQuery : IRequest<List<ShoppingCartDto>>;