using AutoMapper;
using MLS.Application.DTO.ShoppingCartItem;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ShoppingCartItemProfile : Profile
    {
        public ShoppingCartItemProfile()
        {
            CreateMap<ShoppingCartItemDto, ShoppingCartItem>().ReverseMap();
            CreateMap<ShoppingCartItem, ShoppingCartItemDetailsDto>();
            CreateMap<ShoppingCartItem, CreateShoppingCartItemDto>();
            CreateMap<ShoppingCartItem, UpdateShoppingCartItemDto>();
        }
    }
}