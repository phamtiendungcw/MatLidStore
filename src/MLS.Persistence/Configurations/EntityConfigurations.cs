using Microsoft.EntityFrameworkCore;
using MLS.Domain.Entities;

namespace MLS.Persistence.Configurations;

public static class EntityConfigurations
{
    public static void Configure(ModelBuilder modelBuilder, string tablePrefix)
    {
        #region Customize table name

        modelBuilder.Entity<Address>(b => { b.ToTable($"{tablePrefix}Addresses"); });
        modelBuilder.Entity<AppRole>(b => { b.ToTable($"{tablePrefix}Roles"); });
        modelBuilder.Entity<AppUser>(b => { b.ToTable($"{tablePrefix}Users"); });
        modelBuilder.Entity<AppUserRole>(b => { b.ToTable($"{tablePrefix}UserRoles"); });
        modelBuilder.Entity<Article>(b => { b.ToTable($"{tablePrefix}Articles"); });
        modelBuilder.Entity<Category>(b => { b.ToTable($"{tablePrefix}Categories"); });
        modelBuilder.Entity<Comment>(b => { b.ToTable($"{tablePrefix}Comments"); });
        modelBuilder.Entity<Discount>(b => { b.ToTable($"{tablePrefix}Discounts"); });
        modelBuilder.Entity<Notification>(b => { b.ToTable($"{tablePrefix}Notifications"); });
        modelBuilder.Entity<Order>(b => { b.ToTable($"{tablePrefix}Orders"); });
        modelBuilder.Entity<OrderDetail>(b => { b.ToTable($"{tablePrefix}OrderDetails"); });
        modelBuilder.Entity<Payment>(b => { b.ToTable($"{tablePrefix}Payments"); });
        modelBuilder.Entity<Product>(b => { b.ToTable($"{tablePrefix}Products"); });
        modelBuilder.Entity<ProductColor>(b => { b.ToTable($"{tablePrefix}ProductColors"); });
        modelBuilder.Entity<ProductImage>(b => { b.ToTable($"{tablePrefix}ProductImages"); });
        modelBuilder.Entity<ProductOption>(b => { b.ToTable($"{tablePrefix}ProductOptions"); });
        modelBuilder.Entity<ProductReview>(b => { b.ToTable($"{tablePrefix}ProductReviews"); });
        modelBuilder.Entity<ProductTag>(b => { b.ToTable($"{tablePrefix}ProductTags"); });
        modelBuilder.Entity<Shipment>(b => { b.ToTable($"{tablePrefix}Shipments"); });
        modelBuilder.Entity<ShoppingCart>(b => { b.ToTable($"{tablePrefix}ShoppingCarts"); });
        modelBuilder.Entity<ShoppingCartItem>(b => { b.ToTable($"{tablePrefix}ShoppingCartItems"); });
        modelBuilder.Entity<Supplier>(b => { b.ToTable($"{tablePrefix}Suppliers"); });
        modelBuilder.Entity<Supply>(b => { b.ToTable($"{tablePrefix}Supplies"); });
        modelBuilder.Entity<Tag>(b => { b.ToTable($"{tablePrefix}Tags"); });
        modelBuilder.Entity<WishList>(b => { b.ToTable($"{tablePrefix}WishLists"); });
        modelBuilder.Entity<WishListItem>(b => { b.ToTable($"{tablePrefix}WishListItems"); });

        #endregion Customize table name

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
            .HasOne(o => o.AppUser)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Address>()
            .HasOne(a => a.AppUser)
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
            .HasOne(n => n.AppUser)
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
            .HasOne(pr => pr.AppUser)
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
            .HasOne(sc => sc.AppUser)
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
            .HasOne(wl => wl.AppUser)
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
}