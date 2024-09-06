namespace MLS.Application.Models.Identity;

public class JwtSettings
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public double DurationInHours { get; set; } = 1;    // Default to 1 hour if not set
}