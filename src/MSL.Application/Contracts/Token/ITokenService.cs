using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Token;

public interface ITokenService
{
    string CreateToken(AppUser user);
}