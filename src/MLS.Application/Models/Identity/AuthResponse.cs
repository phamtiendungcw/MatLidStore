using System.ComponentModel.DataAnnotations.Schema;

namespace MLS.Application.Models.Identity;

public class AuthResponse
{
    public int Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    [NotMapped] public string FullName { get; set; } = string.Empty;

    [NotMapped] public string Token { get; set; } = string.Empty;
}