using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MLS.Identity.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        builder.HasData(
            new IdentityUserRole<string>
            {
                RoleId = "1129c04c-e043-4342-bb9c-e1a3f85195dc",
                UserId = "4f8796e6-4e58-4f7e-b009-10ca8ed95ba3"
            },
            new IdentityUserRole<string>
            {
                RoleId = "36c6ffef-5370-4f63-b0a3-5263feaebc59",
                UserId = "9b0ef8fc-ce4b-4593-9258-8d1dffb6d9a1"
            });
    }
}