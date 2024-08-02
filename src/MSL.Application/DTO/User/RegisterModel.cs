using System.ComponentModel.DataAnnotations;

namespace MLS.Application.DTO.User
{
    public class RegisterModel
    {
        [Required] public string Username { get; set; } = null!;

        [Required][EmailAddress] public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}