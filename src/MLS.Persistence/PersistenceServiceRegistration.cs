using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLS.Application.Contracts.Persistence;
using MLS.Application.Contracts.Persistence.Common;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MatLidStoreDatabaseContext>(options => { options.UseSqlServer(configuration.GetConnectionString("MatLidConnectionString")); });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAddressRepository), typeof(AddressRepository));
            services.AddScoped(typeof(ICartItemRepository), typeof(CartItemRepository));
            services.AddScoped(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            services.AddScoped(typeof(IDeliveryRepository), typeof(DeliveryRepository));
            services.AddScoped(typeof(IInventoryRepository), typeof(InventoryRepository));
            services.AddScoped(typeof(IInvoiceRepository), typeof(InvoiceRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
            services.AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository));
            services.AddScoped(typeof(IProductRepository), typeof(ProductRepository));
            services.AddScoped(typeof(IProductImageRepository), typeof(ProductImageRepository));
            services.AddScoped(typeof(IPromotionRepository), typeof(PromotionRepository));
            services.AddScoped(typeof(IReviewRepository), typeof(ReviewRepository));
            services.AddScoped(typeof(ISupplierRepository), typeof(SupplierRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IWishListRepository), typeof(WishListRepository));

            return services;
        }
    }
}