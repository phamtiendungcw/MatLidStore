using Microsoft.EntityFrameworkCore;
using MLS.Domain.Common;
using MLS.Domain.Entities;

namespace MLS.Persistence.DatabaseContext
{
    public class MatLidStoreDatabaseContext : DbContext
    {
        public MatLidStoreDatabaseContext(DbContextOptions<MatLidStoreDatabaseContext> options) : base(options)
        {
        }

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
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistItem> WishlistItems { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MatLidStoreDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}