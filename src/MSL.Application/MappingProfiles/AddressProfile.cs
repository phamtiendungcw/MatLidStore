using AutoMapper;
using MLS.Application.DTO.Address;
using MLS.Application.Features.Address.Commands.CreateAddressCommand;
using MLS.Application.Features.Address.Commands.DeleteAddressCommand;
using MLS.Application.Features.Address.Commands.UpdateAddressCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<Address, AddressDetailDto>();
            CreateMap<Address, CreateAddressCommand>();
            CreateMap<Address, UpdateAddressCommand>();
            CreateMap<Address, DeleteAddressCommand>();
        }
    }
}