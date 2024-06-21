using AutoMapper;
using MLS.Application.DTO.Discount;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
            CreateMap<DiscountDto, Discount>().ReverseMap();
            CreateMap<Discount, DiscountDetailsDto>();
            CreateMap<CreateDiscountDto, Discount>();
            CreateMap<UpdateDiscountDto, Discount>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}