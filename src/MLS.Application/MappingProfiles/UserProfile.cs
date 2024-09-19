using AutoMapper;
using MLS.Application.DTO.User;
using MLS.Application.Models.Identity;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, AppUser>().ReverseMap();
        CreateMap<AppUser, UserDetailsDto>();
        CreateMap<CreateUserDto, AppUser>();
        CreateMap<UpdateUserDto, AppUser>();
        CreateMap<AppUser, AuthResponse>();
        CreateMap<RegistrationRequest, AppUser>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username.ToLower()));
    }
}