using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class WishListRepository : GenericRepository<WishList>, IWishListRepository
    {
        private readonly MatLidStoreDatabaseContext _context;

        public WishListRepository(MatLidStoreDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<WishList>> GetWishListsByUserIdAsync(int userId)
        {
            return await _context.WishLists.Where(wl => wl.UserId == userId).ToListAsync();
        }
    }
}