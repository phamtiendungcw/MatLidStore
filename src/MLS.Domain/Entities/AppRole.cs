using Microsoft.AspNetCore.Identity;

namespace MLS.Domain.Entities;

public class AppRole : IdentityRole<int>
{
    public ICollection<AppUserRole> UserRoles { get; set; } = new List<AppUserRole>();
}