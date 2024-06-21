using AutoMapper;
using MLS.Application.DTO.Shipment;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            CreateMap<ShipmentDto, Shipment>().ReverseMap();
            CreateMap<Shipment, ShipmentDetailsDto>();
            CreateMap<CreateShipmentDto, Shipment>();
            CreateMap<UpdateShipmentDto, Shipment>();
        }
    }
}