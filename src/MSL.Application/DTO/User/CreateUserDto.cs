using Microsoft.AspNetCore.Identity;

namespace MLS.Application.DTO.User;

public class CreateUserDto : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}