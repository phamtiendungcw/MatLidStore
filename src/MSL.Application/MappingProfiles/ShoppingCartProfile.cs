using AutoMapper;
using MLS.Application.DTO.ShoppingCart;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ShoppingCartProfile : Profile
    {
        public ShoppingCartProfile()
        {
            CreateMap<ShoppingCartDto, ShoppingCart>().ReverseMap();
            CreateMap<ShoppingCart, ShoppingCartDetailsDto>();
            CreateMap<CreateShoppingCartDto, ShoppingCart>();
            CreateMap<UpdateShoppingCartDto, ShoppingCart>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}