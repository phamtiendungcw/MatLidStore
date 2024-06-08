using AutoMapper;
using MLS.Application.DTO.User;
using MLS.Application.Features.User.Commands.CreateUserCommand;
using MLS.Application.Features.User.Commands.DeleteUserCommand;
using MLS.Application.Features.User.Commands.UpdateUserCommand;
using MLS.Domain.Entities;

namespace MLS.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, UserDetailDto>();
            CreateMap<User, CreateUserCommand>();
            CreateMap<User, UpdateUserCommand>();
            CreateMap<User, DeleteUserCommand>();
        }
    }
}