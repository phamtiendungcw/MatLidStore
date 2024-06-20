using AutoMapper;
using MLS.Application.DTO.WishList;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class WishListProfile : Profile
    {
        public WishListProfile()
        {
            CreateMap<WishListDto, WishList>().ReverseMap();
            CreateMap<WishList, WishListDetailsDto>();
            CreateMap<WishList, CreateWishListDto>();
            CreateMap<WishList, UpdateWishListDto>();
        }
    }
}