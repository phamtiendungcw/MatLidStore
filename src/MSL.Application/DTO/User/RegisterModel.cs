using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Application.DTO.User;

public class RegisterModel
{
    public string Username { get; set; } = string.Empty;
    [EmailAddress] public string Email { get; set; } = string.Empty;
    [NotMapped] public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty; // User's FirstName
    public string LastName { get; set; } = string.Empty; // User's LastName
    [Phone] public string Phone { get; set; } = string.Empty; // User's phone number
}