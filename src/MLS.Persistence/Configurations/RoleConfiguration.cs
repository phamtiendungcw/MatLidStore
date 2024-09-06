using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MLS.Domain.Entities;

namespace MLS.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<AppRole>
{
    public void Configure(EntityTypeBuilder<AppRole> builder)
    {
        builder.HasData(
            new AppRole
            {
                Id = 1,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            },
            new AppRole
            {
                Id = 2,
                Name = "Employee",
                NormalizedName = "EMPLOYEE"
            }
        );
    }
}