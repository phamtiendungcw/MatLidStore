using AutoMapper;
using MLS.Application.DTO.Product;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Product, ProductDetailsDto>();
            CreateMap<Product, CreateProductDto>();
            CreateMap<Product, UpdateProductDto>();
        }
    }
}