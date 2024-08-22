using MediatR;
using MLS.Application.DTO.User;

namespace MLS.Application.Features.User.Queries.GetUserDetailsByUserName;

public record GetUserDetailsByUserNameQuery(LoginModel loginUser) : IRequest<UserDetailsDto>;