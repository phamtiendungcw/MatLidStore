using System.ComponentModel.DataAnnotations;

namespace MLS.Application.DTO.User
{
    public class RegisterModel
    {
        [Required] public string Username { get; set; }

        [Required][EmailAddress] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}