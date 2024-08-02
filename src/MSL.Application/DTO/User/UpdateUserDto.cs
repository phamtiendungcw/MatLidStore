using Microsoft.AspNetCore.Identity;

namespace MLS.Application.DTO.User;

public class UpdateUserDto : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Phone { get; set; }
}