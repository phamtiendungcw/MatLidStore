using AutoMapper;
using MLS.Application.DTO.Delivery;
using MLS.Application.Features.Delivery.Commands.CreateDeliveryCommand;
using MLS.Application.Features.Delivery.Commands.DeleteDeliveryCommand;
using MLS.Application.Features.Delivery.Commands.UpdateDeliveryCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class DeliveryProfile : Profile
    {
        public DeliveryProfile()
        {
            CreateMap<DeliveryDto, Delivery>().ReverseMap();
            CreateMap<Delivery, DeliveryDetailDto>();
            CreateMap<Delivery, CreateDeliveryCommand>();
            CreateMap<Delivery, UpdateDeliveryCommand>();
            CreateMap<Delivery, DeleteDeliveryCommand>();
        }
    }
}