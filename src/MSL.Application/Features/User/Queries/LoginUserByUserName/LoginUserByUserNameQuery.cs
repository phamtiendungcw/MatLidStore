using MediatR;
using MLS.Application.Models.Identity;

namespace MLS.Application.Features.User.Queries.LoginUserByUserName;

public record LoginUserByUserNameQuery(AuthRequest model) : IRequest<AuthResponse>;