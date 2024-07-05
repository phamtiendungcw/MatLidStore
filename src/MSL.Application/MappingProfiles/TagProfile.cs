using AutoMapper;
using MLS.Application.DTO.Tag;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class TagProfile : Profile
{
    public TagProfile()
    {
        CreateMap<TagDto, Tag>().ReverseMap();
        CreateMap<Tag, TagDetailsDto>();
        CreateMap<CreateTagDto, Tag>();
        CreateMap<UpdateTagDto, Tag>();
    }
}