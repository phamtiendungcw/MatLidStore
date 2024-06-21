using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class ProductColorRepository : GenericRepository<ProductColor>, IProductColorRepository
    {
        private readonly MatLidStoreDatabaseContext _context;

        public ProductColorRepository(MatLidStoreDatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> IsColorNameUniqueAsync(string colorName)
        {
            return !await _context.ProductColors.AnyAsync(pc => pc.ColorName == colorName);
        }

        public override async Task CreateAsync(ProductColor entity)
        {
            if (!await IsColorNameUniqueAsync(entity.ColorName))
            {
                throw new InvalidOperationException("Color name must be unique.");
            }

            await base.CreateAsync(entity);
        }

        public override async Task UpdateAsync(ProductColor entity)
        {
            if (!await IsColorNameUniqueAsync(entity.ColorName))
            {
                throw new InvalidOperationException("Color name must be unique.");
            }

            await base.UpdateAsync(entity);
        }
    }
}