using AutoMapper;
using MLS.Application.DTO.WishListItem;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class WishListItemProfile : Profile
    {
        public WishListItemProfile()
        {
            CreateMap<WishListItemDto, WishListItem>().ReverseMap();
            CreateMap<WishListItem, WishListItemDetailsDto>();
            CreateMap<WishListItem, CreateWishListItemDto>();
            CreateMap<WishListItem, UpdateWishListItemDto>();
        }
    }
}