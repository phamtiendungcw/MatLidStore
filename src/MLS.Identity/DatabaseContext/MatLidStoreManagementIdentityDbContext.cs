using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MLS.Identity.Models;

namespace MLS.Identity.DatabaseContext;

public class MatLidStoreManagementIdentityDbContext : IdentityDbContext<ApplicationUser>
{
    public MatLidStoreManagementIdentityDbContext(DbContextOptions<MatLidStoreManagementIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(MatLidStoreManagementIdentityDbContext).Assembly);
    }
}