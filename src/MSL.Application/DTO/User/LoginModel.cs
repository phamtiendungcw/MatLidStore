using System.ComponentModel.DataAnnotations;

namespace MLS.Application.DTO.User;

public class LoginModel
{
    [Required] public string Username { get; set; } = null!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}