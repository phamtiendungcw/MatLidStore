using MediatR;
using MLS.Application.DTO.User;

namespace MLS.Application.Features.User.Queries.GetUserDetails
{
    public abstract record GetUserDetailsQuery(int Id) : IRequest<UserDetailsDto>;
}