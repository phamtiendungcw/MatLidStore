using MediatR;
using MLS.Application.DTO.User;

namespace MLS.Application.Features.User.Queries.GetAllUsers
{
    public record GetAllUsersQuery : IRequest<List<UserDto>>;
}