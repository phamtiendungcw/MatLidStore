using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Application.DTO.User;

public class RegisterModel
{
    public string Username { get; set; } = string.Empty;
    [NotMapped] public string Password { get; set; } = string.Empty;
    public string? PasswordHash { get; set; }
    public byte[]? PasswordSalt { get; set; }
    public string FirstName { get; set; } = string.Empty; // AppUser's FirstName
    public string LastName { get; set; } = string.Empty; // AppUser's LastName
    public string Phone { get; set; } = string.Empty; // AppUser's phone number
}