using AutoMapper;
using MLS.Application.DTO.Promotion;
using MLS.Application.Features.Promotion.Commands.CreatePromotionCommand;
using MLS.Application.Features.Promotion.Commands.DeletePromotionCommand;
using MLS.Application.Features.Promotion.Commands.UpdatePromotionCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class PromotionProfile : Profile
    {
        public PromotionProfile()
        {
            CreateMap<PromotionDto, Promotion>().ReverseMap();
            CreateMap<Promotion, PromotionDetailDto>();
            CreateMap<Promotion, CreatePromotionCommand>();
            CreateMap<Promotion, UpdatePromotionCommand>();
            CreateMap<Promotion, DeletePromotionCommand>();
        }
    }
}