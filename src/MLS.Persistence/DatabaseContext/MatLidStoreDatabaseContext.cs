using Microsoft.EntityFrameworkCore;
using MLS.Domain.Common;
using MLS.Domain.Entities;
using MLS.Persistence.Configurations;

namespace MLS.Persistence.DatabaseContext;

public class MatLidStoreDatabaseContext : DbContext
{
    private readonly string _tablePrefix = "MATLID_";

    public MatLidStoreDatabaseContext(DbContextOptions<MatLidStoreDatabaseContext> options) : base(options)
    {
    }

    #region Defines a set of entities in the database

    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<AppRole> Roles { get; set; } = null!;
    public DbSet<AppUser> Users { get; set; } = null!;
    public DbSet<AppUserRole> UserRoles { get; set; } = null!;
    public DbSet<Article> Articles { get; set; } = null!;
    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Discount> Discounts { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    public DbSet<Payment> Payments { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductColor> ProductColors { get; set; } = null!;
    public DbSet<ProductImage> ProductImages { get; set; } = null!;
    public DbSet<ProductOption> ProductOptions { get; set; } = null!;
    public DbSet<ProductReview> ProductReviews { get; set; } = null!;
    public DbSet<ProductTag> ProductTags { get; set; } = null!;
    public DbSet<Shipment> Shipments { get; set; } = null!;
    public DbSet<ShoppingCart> ShoppingCarts { get; set; } = null!;
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;
    public DbSet<Supply> Supplies { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
    public DbSet<WishList> WishLists { get; set; } = null!;
    public DbSet<WishListItem> WishListItems { get; set; } = null!;

    #endregion Defines a set of entities in the database

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
        {
            entry.Entity.UpdatedAt = DateTime.UtcNow;

            if (entry.State == EntityState.Added) entry.Entity.CreatedAt = DateTime.UtcNow;
        }

        SoftDeleteEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MatLidStoreDatabaseContext).Assembly);
        base.OnModelCreating(modelBuilder);
        EntityConfigurations.Configure(modelBuilder, _tablePrefix);
    }

    private void SoftDeleteEntities()
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted))
            if (entry.Entity is BaseEntity entity)
            {
                entry.State = EntityState.Modified;
                entity.IsDeleted = true;
            }
    }
}