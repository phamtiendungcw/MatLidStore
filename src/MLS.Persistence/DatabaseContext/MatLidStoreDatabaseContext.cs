using Microsoft.EntityFrameworkCore;
using MLS.Domain.Common;

namespace MLS.Persistence.DatabaseContext
{
    public class MatLidStoreDatabaseContext : DbContext
    {
        public MatLidStoreDatabaseContext(DbContextOptions<MatLidStoreDatabaseContext> options) : base(options)
        {
        }

        public DbSet<Domain.Entities.Address> Addresses { get; set; }
        public DbSet<Domain.Entities.CartItem> CartItems { get; set; }
        public DbSet<Domain.Entities.Category> Categories { get; set; }
        public DbSet<Domain.Entities.Customer> Customers { get; set; }
        public DbSet<Domain.Entities.Delivery> Deliveries { get; set; }
        public DbSet<Domain.Entities.Feedback> Feedbacks { get; set; }
        public DbSet<Domain.Entities.Inventory> Inventories { get; set; }
        public DbSet<Domain.Entities.Invoice> Invoices { get; set; }
        public DbSet<Domain.Entities.News> News { get; set; }
        public DbSet<Domain.Entities.Order> Orders { get; set; }
        public DbSet<Domain.Entities.OrderDetail> OrderDetails { get; set; }
        public DbSet<Domain.Entities.OrderStatus> OrderStatus { get; set; }
        public DbSet<Domain.Entities.Payment> Payments { get; set; }
        public DbSet<Domain.Entities.PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Domain.Entities.Product> Products { get; set; }
        public DbSet<Domain.Entities.ProductImage> ProductImages { get; set; }
        public DbSet<Domain.Entities.Promotion> Promotions { get; set; }
        public DbSet<Domain.Entities.Review> Reviews { get; set; }
        public DbSet<Domain.Entities.Supplier> Suppliers { get; set; }
        public DbSet<Domain.Entities.User> Users { get; set; }
        public DbSet<Domain.Entities.WishList> WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MatLidStoreDatabaseContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
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