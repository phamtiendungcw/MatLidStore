using MediatR;
using MLS.Application.DTO.WishList;

namespace MLS.Application.Features.WishList.Commands.CreateWishListCommand
{
    public abstract class CreateWishListCommand : IRequest<int>
    {
        public CreateWishListDto WishList { get; set; }
    }
}