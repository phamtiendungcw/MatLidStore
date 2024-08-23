using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MLS.Application.Contracts.Token;
using MLS.Domain.Entities;

namespace MLS.Persistence.Auth;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;

    public TokenService(IConfiguration config)
    {
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    public string GenerateJwtToken(AppUser user)
    {
        var tokenKey = GetTokenKey();
        var key = Encoding.ASCII.GetBytes(tokenKey);
        var tokenDescriptor = CreateTokenDescriptor(user, key);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    private string GetTokenKey()
    {
        var tokenKey = _config["TokenKey"] ?? throw new InvalidOperationException("Cannot access 'TokenKey' from app settings.");
        if (tokenKey.Length < 64)
            throw new ArgumentOutOfRangeException(nameof(tokenKey), "Your 'TokenKey' needs to be longer than 64 characters.");

        return tokenKey;
    }

    private SecurityTokenDescriptor CreateTokenDescriptor(AppUser user, byte[] key)
    {
        return new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            }),
            Expires = DateTime.UtcNow.AddHours(8),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
        };
    }
}