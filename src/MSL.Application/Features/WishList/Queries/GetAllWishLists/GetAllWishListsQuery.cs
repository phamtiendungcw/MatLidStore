using MediatR;
using MLS.Application.DTO.WishList;

namespace MLS.Application.Features.WishList.Queries.GetAllWishLists
{
    public record GetAllWishListsQuery : IRequest<List<WishListDto>>;
}