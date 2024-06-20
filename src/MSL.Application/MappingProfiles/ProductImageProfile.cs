using AutoMapper;
using MLS.Application.DTO.ProductImage;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile()
        {
            CreateMap<ProductImageDto, ProductImage>().ReverseMap();
            CreateMap<ProductImage, ProductImageDetailsDto>();
            CreateMap<ProductImage, CreateProductImageDto>();
            CreateMap<ProductImage, UpdateProductImageDto>();
        }
    }
}