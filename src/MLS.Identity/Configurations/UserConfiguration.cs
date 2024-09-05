using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLS.Identity.Models;

namespace MLS.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "4f8796e6-4e58-4f7e-b009-10ca8ed95ba3",
                    Email = "admin@matlidstore.com",
                    NormalizedEmail = "ADMIN@MATLIDSTORE.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    PasswordHash = hasher.HashPassword(null!, "Matlidstore2024@"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "9b0ef8fc-ce4b-4593-9258-8d1dffb6d9a1",
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
}
