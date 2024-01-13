using AutoMapper;
using MLS.Application.DTO.Product;
using MLS.Application.Features.Product.Commands.CreateProductCommand;
using MLS.Application.Features.Product.Commands.DeleteProductCommand;
using MLS.Application.Features.Product.Commands.UpdateProductCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<Product, ProductDetailDto>();
            CreateMap<Product, CreateProductCommand>();
            CreateMap<Product, UpdateProductCommand>();
            CreateMap<Product, DeleteProductCommand>();
        }
    }
}
