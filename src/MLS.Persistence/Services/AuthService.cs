using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MLS.Application.Contracts.Identity;
using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;
using MLS.Application.DTO.ProductReview;
using MLS.Application.DTO.WishList;
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
        var user = await _userManager.Users
            .Include(u => u.UserRoles) // Include related Roles
            .Include(u => u.Orders) // Include related Orders
            .Include(u => u.ProductReviews) // Include related ProductReviews
            .Include(u => u.WishLists) // Include related WishLists
            .Include(u => u.Comments) // Include related Comments
            .Include(u => u.Notifications) // Include related Notifications
            .SingleOrDefaultAsync(u => u.UserName == request.Username);

        // Throw exception if the user is not found
        if (user == null)
            throw new NotFoundException($"User with username '{request.Username}' not found.");

        // Check if the password is valid
        var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

        // Throw exception if the credentials are invalid
        if (!result.Succeeded)
            throw new BadRequestException($"Credentials for '{request.Username}' are not valid.");

        // Generate JWT token
        var jwtSecurityToken = await GenerateToken(user);

        // Create and return AuthResponse
        return new AuthResponse
        {
            Id = user.Id,
            UserName = user.UserName,
            Email = user.Email,
            FullName = $"{user.FirstName} {user.LastName}",
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
            Orders = _mapper.Map<List<OrderDto>>(user.Orders),
            ProductReviews = _mapper.Map<List<ProductReviewDto>>(user.ProductReviews),
            WishLists = _mapper.Map<List<WishListDto>>(user.WishLists),
            Comments = _mapper.Map<List<CommentDto>>(user.Comments),
            Notifications = _mapper.Map<List<NotificationDto>>(user.Notifications)
        };
    }

    public async Task<RegistrationResponse> Register(RegistrationRequest request)
    {
        // Check if the user already exists
        if (await UserExists(request.Username))
            throw new BadRequestException($"User with username {request.Username} already exists.");

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
        return !await _userManager.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
}