using Microsoft.AspNetCore.Identity;

namespace MLS.Domain.Entities;

public class AppUserRole : IdentityRole<int>
{
    public AppUser AppUser { get; set; } = null!;
    public AppRole Role { get; set; } = null!;
}