﻿using AutoMapper;
using MLS.Application.DTO.Comment;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<Comment, CommentDetailsDto>();
            CreateMap<Comment, CreateCommentDto>();
            CreateMap<Comment, UpdateCommentDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}