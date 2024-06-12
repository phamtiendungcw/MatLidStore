using AutoMapper;
using MLS.Application.DTO.Order;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<Order, OrderDetailsDto>();
        }
    }
}