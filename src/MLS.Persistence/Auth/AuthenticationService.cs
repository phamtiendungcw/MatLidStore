using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MLS.Application.Contracts.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MLS.Persistence.Auth;

public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthenticationService(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<string> GenerateJwtTokenAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username);
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<bool> ValidateUserCredentialsAsync(string username, string password)
    {
        var user = await _userManager.FindByNameAsync(username);
        return user != null && await _userManager.CheckPasswordAsync(user, password);
    }
}

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task CreateUserAsync(string username, string password, string role)
    {
        var user = new IdentityUser { UserName = username };
        await _userManager.CreateAsync(user, password);
        await _userManager.AddToRoleAsync(user, role);
    }
}