using AutoMapper;
using MLS.Application.DTO.User;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, UserDetailsDto>();
            CreateMap<User, CreateUserDto>();
            CreateMap<User, UpdateUserDto>();
        }
    }
}