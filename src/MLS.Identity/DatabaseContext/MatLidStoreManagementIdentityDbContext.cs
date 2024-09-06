using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MLS.Domain.Entities;

namespace MLS.Identity.DatabaseContext;

public class MatLidStoreManagementIdentityDbContext : IdentityDbContext<AppUser, AppRole, int>
{
    private readonly string _tablePrefix = "MATLID_";

    public MatLidStoreManagementIdentityDbContext(DbContextOptions<MatLidStoreManagementIdentityDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Áp dụng tất cả cấu hình từ assembly hiện tại
        builder.ApplyConfigurationsFromAssembly(typeof(MatLidStoreManagementIdentityDbContext).Assembly);

        // Cấu hình khóa cho IdentityUserRole<int> (kiểu gốc)
        builder.Entity<IdentityUserRole<int>>().HasKey(ur => new { ur.UserId, ur.RoleId });
    }
}