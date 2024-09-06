using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLS.Application.Contracts.Persistence.Common;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MatLidStoreDatabaseContext>(options => { options.UseOracle(configuration.GetConnectionString("MatLidOracleDBConnectionString")); });
        services.AddCors(options => { options.AddPolicy("MatLidStoreUI", b => b.WithOrigins("https://localhost:4200", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod()); });
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<IDiscountRepository, DiscountRepository>();
        services.AddScoped<INotificationRepository, NotificationRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IProductColorRepository, ProductColorRepository>();
        services.AddScoped<IProductImageRepository, ProductImageRepository>();
        services.AddScoped<IProductOptionRepository, ProductOptionRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IProductReviewRepository, ProductReviewRepository>();
        services.AddScoped<IProductTagRepository, ProductTagRepository>();
        services.AddScoped<IShipmentRepository, ShipmentRepository>();
        services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
        services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();
        services.AddScoped<ISupplyRepository, SupplyRepository>();
        services.AddScoped<ITagRepository, TagRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWishListItemRepository, WishListItemRepository>();
        services.AddScoped<IWishListRepository, WishListRepository>();

        return services;
    }
}