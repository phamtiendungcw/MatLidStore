using AutoMapper;
using MLS.Application.DTO.Address;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}