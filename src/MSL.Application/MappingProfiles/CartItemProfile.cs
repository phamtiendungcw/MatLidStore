using AutoMapper;
using MLS.Application.DTO.CartItem;
using MLS.Application.Features.CartItem.Commands.CreateCartItemCommand;
using MLS.Application.Features.CartItem.Commands.DeleteCartItemCommand;
using MLS.Application.Features.CartItem.Commands.UpdateCartItemCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class CartItemProfile : Profile
    {
        public CartItemProfile()
        {
            CreateMap<CartItemDto, CartItem>().ReverseMap();
            CreateMap<CartItem, CartItemDetailDto>();
            CreateMap<CartItem, CreateCartItemCommand>();
            CreateMap<CartItem, UpdateCartItemCommand>();
            CreateMap<CartItem, DeleteCartItemCommand>();
        }
    }
}
