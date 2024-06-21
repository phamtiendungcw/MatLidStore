﻿using AutoMapper;
using MLS.Application.DTO.Category;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDetailsDto>();
            CreateMap<Category, CreateCategoryDto>();
            CreateMap<Category, UpdateCategoryDto>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}