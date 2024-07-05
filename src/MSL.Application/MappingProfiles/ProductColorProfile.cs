using AutoMapper;
using MLS.Application.DTO.ProductColor;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class ProductColorProfile : Profile
{
    public ProductColorProfile()
    {
        CreateMap<ProductColorDto, ProductColor>().ReverseMap();
        CreateMap<ProductColor, ProductColorDetailsDto>();
        CreateMap<CreateProductColorDto, ProductColor>();
        CreateMap<UpdateProductColorDto, ProductColor>();
    }
}