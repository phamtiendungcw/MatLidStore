using AutoMapper;
using MLS.Application.DTO.ProductTag;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ProductTagProfile : Profile
    {
        public ProductTagProfile()
        {
            CreateMap<ProductTagDto, ProductTag>().ReverseMap();
            CreateMap<ProductTag, ProductTagDetailsDto>();
            CreateMap<ProductTag, CreateProductTagDto>();
            CreateMap<ProductTag, UpdateProductTagDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}