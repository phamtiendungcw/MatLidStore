using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class ShoppingCartRepository : GenericRepository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly MatLidStoreDatabaseContext _context;

        public ShoppingCartRepository(MatLidStoreDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ShoppingCart?> GetCartByUserIdAsync(int userId)
        {
            return await _context.ShoppingCarts
                                 .Include(sc => sc.ShoppingCartItems)
                                 .FirstOrDefaultAsync(sc => sc.UserId == userId);
        }
    }
}