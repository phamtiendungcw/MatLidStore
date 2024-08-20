using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Application.DTO.User
{
    public class RegisterModel
    {
        public string Username { get; set; } = string.Empty;

        [NotMapped]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        [MaxLength(50)] public string FirstName { get; set; } = string.Empty; // AppUser's FirstName
        [MaxLength(50)] public string LastName { get; set; } = string.Empty; // AppUser's LastName
        [Phone] public string Phone { get; set; } = string.Empty; // AppUser's phone number
    }
}