using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class SupplyRepository : GenericRepository<Supply>, ISupplyRepository
    {
        private readonly MatLidStoreDatabaseContext _context;

        public SupplyRepository(MatLidStoreDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supply>> GetSuppliesByProductIdAsync(int productId)
        {
            return await _context.Supplies.Where(s => s.ProductId == productId).ToListAsync();
        }
    }
}