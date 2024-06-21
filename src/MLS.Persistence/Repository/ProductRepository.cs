using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly MatLidStoreDatabaseContext _context;

        public ProductRepository(MatLidStoreDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryIdAsync(int categoryId)
        {
            return await _context.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
        }

        public async Task<bool> IsProductNameUniqueAsync(string name)
        {
            return !await _context.Products.AnyAsync(p => p.Name == name);
        }

        public override async Task CreateAsync(Product entity)
        {
            if (!await IsProductNameUniqueAsync(entity.Name))
            {
                throw new InvalidOperationException("Product name must be unique.");
            }

            await base.CreateAsync(entity);
        }

        public override async Task UpdateAsync(Product entity)
        {
            if (!await IsProductNameUniqueAsync(entity.Name))
            {
                throw new InvalidOperationException("Product name must be unique.");
            }

            await base.UpdateAsync(entity);
        }
    }
}