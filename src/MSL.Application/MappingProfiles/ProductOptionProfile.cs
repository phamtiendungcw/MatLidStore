using AutoMapper;
using MLS.Application.DTO.ProductOption;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class ProductOptionProfile : Profile
{
    public ProductOptionProfile()
    {
        CreateMap<ProductOptionDto, ProductOption>().ReverseMap();
        CreateMap<ProductOption, ProductOptionDetailsDto>();
        CreateMap<CreateProductOptionDto, ProductOption>();
        CreateMap<UpdateProductOptionDto, ProductOption>();
    }
}