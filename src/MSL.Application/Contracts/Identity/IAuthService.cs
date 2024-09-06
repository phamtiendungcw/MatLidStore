using MLS.Application.DTO.User;
using MLS.Application.Models.Identity;

namespace MLS.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);

    Task<RegistrationResponse> Register(RegisterModel request);
}