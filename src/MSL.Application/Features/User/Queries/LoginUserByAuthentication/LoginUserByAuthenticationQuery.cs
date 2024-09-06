using MediatR;
using MLS.Application.Models.Identity;

namespace MLS.Application.Features.User.Queries.LoginUserByAuthentication;

public record LoginUserByAuthenticationQuery(AuthRequest model) : IRequest<AuthResponse>;