using AutoMapper;
using MLS.Application.DTO.ProductReview;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ProductReviewProfile : Profile
    {
        public ProductReviewProfile()
        {
            CreateMap<ProductReviewDto, ProductReview>();
            CreateMap<ProductReview, ProductReviewDetailsDto>();
            CreateMap<ProductReview, CreateProductReviewDto>();
            CreateMap<ProductReview, UpdateProductReviewDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}