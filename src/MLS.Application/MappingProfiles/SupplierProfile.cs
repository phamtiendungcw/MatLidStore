using AutoMapper;
using MLS.Application.DTO.Supplier;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class SupplierProfile : Profile
{
    public SupplierProfile()
    {
        CreateMap<SupplierDto, Supplier>().ReverseMap();
        CreateMap<Supplier, SupplierDetailsDto>();
        CreateMap<CreateSupplierDto, Supplier>();
        CreateMap<UpdateSupplierDto, Supplier>();
    }
}