using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class ShoppingCartItemRepository : GenericRepository<ShoppingCartItem>, IShoppingCartItemRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public ShoppingCartItemRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ShoppingCartItem>> GetItemsByCartIdAsync(int cartId)
    {
        return await _context.ShoppingCartItems.Where(sci => sci.ShoppingCartId == cartId).ToListAsync();
    }
}