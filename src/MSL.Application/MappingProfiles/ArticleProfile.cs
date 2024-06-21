using AutoMapper;
using MLS.Application.DTO.Article;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<ArticleDto, Article>().ReverseMap();
            CreateMap<Article, ArticleDetailsDto>();
            CreateMap<CreateArticleDto, Article>();
            CreateMap<UpdateArticleDto, Article>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}