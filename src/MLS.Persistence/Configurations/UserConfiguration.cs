using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLS.Domain.Entities;

namespace MLS.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        var hasher = new PasswordHasher<AppUser>();
        builder.HasData(
            new AppUser
            {
                Id = 1,
                Email = "admin@matlidstore.com",
                NormalizedEmail = "ADMIN@MATLIDSTORE.COM",
                FirstName = "System",
                LastName = "Admin",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = hasher.HashPassword(null!, "Matlidstore2024@"),
                EmailConfirmed = true
            },
            new AppUser
            {
                Id = 2,
                Email = "user@matlidstore.com",
                NormalizedEmail = "USER@MATLIDSTORE.COM",
                FirstName = "System",
                LastName = "User",
                UserName = "user",
                NormalizedUserName = "USER",
                PasswordHash = hasher.HashPassword(null!, "Matlidstore2024@"),
                EmailConfirmed = true
            });
    }
}