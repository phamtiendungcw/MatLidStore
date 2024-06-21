using MediatR;
using MLS.Application.DTO.WishList;

namespace MLS.Application.Features.WishList.Queries.GetWishListDetails
{
    public record GetWishListDetailsQuery(int Id) : IRequest<WishListDetailsDto>;
}