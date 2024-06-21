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
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}