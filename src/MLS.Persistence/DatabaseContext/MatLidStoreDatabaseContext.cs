using Microsoft.EntityFrameworkCore;
using MLS.Domain.Common;
using MLS.Domain.Entities;

namespace MLS.Persistence.DatabaseContext;

public class MatLidStoreDatabaseContext : DbContext
{
    public MatLidStoreDatabaseContext(DbContextOptions<MatLidStoreDatabaseContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MatLidStoreDatabaseContext).Assembly);

        base.OnModelCreating(modelBuilder);

        #region Ensure relationships and delete cascading rules

        // Configure the relationship
        modelBuilder.Entity<Comment>()
                    .HasOne(c => c.Commenter)
                    .WithMany(u => u.Comments)
                    .HasForeignKey(c => c.CommenterId)
                    .OnDelete(DeleteBehavior.Restrict); // Or use DeleteBehavior.NoAction

        modelBuilder.Entity<Comment>()
                    .HasOne(c => c.Article)
                    .WithMany(a => a.Comments)
                    .HasForeignKey(c => c.ArticleId)
                    .OnDelete(DeleteBehavior.SetNull);

        modelBuilder.Entity<Order>()
                    .HasOne(o => o.User)
                    .WithMany(u => u.Orders)
                    .HasForeignKey(o => o.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Address>()
                    .HasOne(a => a.User)
                    .WithMany()
                    .HasForeignKey(a => a.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Article>()
                    .HasOne(a => a.AuthorUser)
                    .WithMany()
                    .HasForeignKey(a => a.AuthorUserId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Category>()
                    .HasMany(c => c.Products)
                    .WithOne(p => p.Category)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Notification>()
                    .HasOne(n => n.User)
                    .WithMany(u => u.Notifications)
                    .HasForeignKey(n => n.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderDetail>()
                    .HasOne(od => od.Product)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(od => od.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderDetail>()
                    .HasOne(od => od.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(od => od.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
                    .HasOne(p => p.Order)
                    .WithMany()
                    .HasForeignKey(p => p.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Product>()
                    .HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductColor>()
                    .HasOne(pc => pc.Product)
                    .WithMany(p => p.ProductColors)
                    .HasForeignKey(pc => pc.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductImage>()
                    .HasOne(pi => pi.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(pi => pi.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductOption>()
                    .HasOne(po => po.Product)
                    .WithMany(p => p.ProductOptions)
                    .HasForeignKey(po => po.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductReview>()
                    .HasOne(pr => pr.Product)
                    .WithMany(p => p.ProductReviews)
                    .HasForeignKey(pr => pr.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductReview>()
                    .HasOne(pr => pr.User)
                    .WithMany(u => u.ProductReviews)
                    .HasForeignKey(pr => pr.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductTag>()
                    .HasOne(pt => pt.Product)
                    .WithMany()
                    .HasForeignKey(pt => pt.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProductTag>()
                    .HasOne(pt => pt.Tag)
                    .WithMany(t => t.ProductTags)
                    .HasForeignKey(pt => pt.TagId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Shipment>()
                    .HasOne(s => s.Order)
                    .WithMany()
                    .HasForeignKey(s => s.OrderId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShoppingCart>()
                    .HasOne(sc => sc.User)
                    .WithMany()
                    .HasForeignKey(sc => sc.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShoppingCartItem>()
                    .HasOne(sci => sci.Product)
                    .WithMany()
                    .HasForeignKey(sci => sci.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShoppingCartItem>()
                    .HasOne(sci => sci.ShoppingCart)
                    .WithMany(sc => sc.ShoppingCartItems)
                    .HasForeignKey(sci => sci.ShoppingCartId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Supply>()
                    .HasOne(s => s.Product)
                    .WithMany()
                    .HasForeignKey(s => s.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Supply>()
                    .HasOne(s => s.Supplier)
                    .WithMany()
                    .HasForeignKey(s => s.SupplierId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WishList>()
                    .HasOne(wl => wl.User)
                    .WithMany(u => u.WishLists)
                    .HasForeignKey(wl => wl.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WishListItem>()
                    .HasOne(wli => wli.Product)
                    .WithMany()
                    .HasForeignKey(wli => wli.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<WishListItem>()
                    .HasOne(wli => wli.WishList)
                    .WithMany(wl => wl.WishListItems)
                    .HasForeignKey(wli => wli.WishListId)
                    .OnDelete(DeleteBehavior.Restrict);

        #endregion Ensure relationships and delete cascading rules
    }

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

    private void SoftDeleteEntities()
    {
        foreach (var entry in ChangeTracker.Entries().Where(e => e.State == EntityState.Deleted))
            if (entry.Entity is BaseEntity entity)
            {
                entry.State = EntityState.Modified;
                entity.IsDeleted = true;
            }
    }

    #region Configure DB

    public DbSet<Product> Products { get; set; }
    public DbSet<ProductColor> ProductColors { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductOption> ProductOptions { get; set; }
    public DbSet<ProductReview> ProductReviews { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Supply> Supplies { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<WishList> WishLists { get; set; }
    public DbSet<WishListItem> WishListItems { get; set; }
    public DbSet<ShoppingCart> ShoppingCarts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Shipment> Shipments { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Article> Articles { get; set; }

    #endregion Configure DB
}