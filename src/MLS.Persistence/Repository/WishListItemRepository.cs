using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class WishListItemRepository : GenericRepository<WishListItem>, IWishListItemRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public WishListItemRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WishListItem>> GetItemsByWishListIdAsync(int wishListId)
    {
        return await _context.WishListItems.Where(wli => wli.WishListId == wishListId).ToListAsync();
    }
}