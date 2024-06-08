using AutoMapper;
using MLS.Application.DTO.WishList;
using MLS.Application.Features.WishList.Commands.CreateWishListCommand;
using MLS.Application.Features.WishList.Commands.DeleteWishListCommand;
using MLS.Application.Features.WishList.Commands.UpdateWishListCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class WishListProfile : Profile
    {
        public WishListProfile()
        {
            CreateMap<WishListDto, WishList>().ReverseMap();
            CreateMap<WishList, WishListDetailDto>();
            CreateMap<WishList, CreateWishListCommand>();
            CreateMap<WishList, UpdateWishListCommand>();
            CreateMap<WishList, DeleteWishListCommand>();
        }
    }
}