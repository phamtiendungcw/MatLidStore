using AutoMapper;
using MLS.Application.DTO.Supply;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class SupplyProfileL : Profile
{
    public SupplyProfileL()
    {
        CreateMap<SupplyDto, Supply>().ReverseMap();
        CreateMap<Supply, SupplyDetailsDto>();
        CreateMap<CreateSupplyDto, Supply>();
        CreateMap<UpdateSupplyDto, Supply>();
    }
}