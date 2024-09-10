using AutoMapper;
using MLS.Application.DTO.ProductReview;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class ProductReviewProfile : Profile
{
    public ProductReviewProfile()
    {
        CreateMap<ProductReviewDto, ProductReview>();
        CreateMap<ProductReview, ProductReviewDetailsDto>();
        CreateMap<CreateProductReviewDto, ProductReview>();
        CreateMap<UpdateProductReviewDto, ProductReview>();
    }
}