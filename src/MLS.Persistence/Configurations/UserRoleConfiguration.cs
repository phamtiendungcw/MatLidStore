using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLS.Domain.Entities;

namespace MLS.Persistence.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasData(
            new AppUserRole
            {
                UserId = 1,
                RoleId = 1
            },
            new AppUserRole
            {
                UserId = 2,
                RoleId = 2
            }
        );
    }
}