using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MLS.Application.Contracts.Identity;
using MLS.Application.Exceptions;
using MLS.Application.Models.Identity;
using MLS.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MLS.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IOptions<JwtSettings> _jwtSettings;
    private readonly IMapper _mapper;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;

    public AuthService(UserManager<AppUser> userManager, IOptions<JwtSettings> jwtSettings, SignInManager<AppUser> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _jwtSettings = jwtSettings;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<AuthResponse> Login(AuthRequest request)
    {
        // Find the user by username
        var user = await _userManager.Users.SingleOrDefaultAsync(u => u.UserName == request.Username);

        // Throw exception if the user is not found
        if (user == null)
            throw new NotFoundException($"User name '{request.Username}' not found on the system.");

        // Check if the password is valid
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        // Throw exception if the credentials are invalid
        if (!result.Succeeded)
            throw new BadRequestException($"The credentials for account '{request.Username}' are invalid.");

        // Generate JWT token
        var jwtSecurityToken = await GenerateToken(user);

        var response = _mapper.Map<AuthResponse>(user);
        response.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        response.FullName = user.FirstName + ' ' + user.LastName;

        // Return AuthResponse
        return response;
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        // Check if the user already exists
        if (await UserExists(request.Username))
            throw new BadRequestException($"User name {request.Username} already exists on the system.");

        // Map the RegistrationRequest to AppUser
        var userToCreate = _mapper.Map<AppUser>(request);

        // Attempt to create the user
        var result = await _userManager.CreateAsync(userToCreate, request.Password);

        // Handle errors during user creation
        if (!result.Succeeded)
        {
            var errorMessages = string.Join("\n", result.Errors.Select(e => $"• {e.Description}"));
            throw new BadRequestException(errorMessages);
        }

        // Add user to the default role
        await _userManager.AddToRoleAsync(userToCreate, "Employee");

        // Return the response with the new user ID
        return new RegistrationResponse { UserId = userToCreate.Id };
    }

    private async Task<JwtSecurityToken> GenerateToken(AppUser user)
    {
        // Retrieve user claims and roles
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        // Create role claims
        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

        // Create standard claims
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserName),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Email, user.Email),
            new(JwtRegisteredClaimNames.GivenName, $"{user.FirstName} {user.LastName}"),
            new("uid", user.Id.ToString())
        };

        // Add user claims and role claims
        claims.AddRange(userClaims);
        claims.AddRange(roleClaims);

        if (_jwtSettings.Value.Key.Length < 64) throw new BadRequestException("Token key needs to be longer!");

        // Create security key and signing credentials
        var key = Encoding.UTF8.GetBytes(_jwtSettings.Value.Key);
        var symmetricSecurityKey = new SymmetricSecurityKey(key);
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        // Create JWT token
        var jwtSecurityToken = new JwtSecurityToken(
            _jwtSettings.Value.Issuer,
            _jwtSettings.Value.Audience,
            claims,
            expires: DateTime.UtcNow.AddHours(_jwtSettings.Value.DurationInHours),
            signingCredentials: signingCredentials
        );

        return jwtSecurityToken;
    }

    private async Task<bool> UserExists(string username)
    {
        return await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
}