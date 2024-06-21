using AutoMapper;
using MLS.Application.DTO.OrderDetail;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDetailsDto>();
            CreateMap<CreateOrderDetailDto, OrderDetail>();
            CreateMap<UpdateOrderDetailDto, OrderDetail>();
        }
    }
}