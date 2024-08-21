using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class ProductImageRepository : GenericRepository<ProductImage>, IProductImageRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public ProductImageRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> IsImageUrlUniqueAsync(string imageUrl)
    {
        return !await _context.ProductImages.AnyAsync(pi => pi.ImageUrl == imageUrl);
    }

    public override async Task CreateAsync(ProductImage entity)
    {
        if (!await IsImageUrlUniqueAsync(entity.ImageUrl))
            throw new InvalidOperationException("Image URL must be unique.");

        await base.CreateAsync(entity);
    }

    public override async Task UpdateAsync(ProductImage entity)
    {
        if (!await IsImageUrlUniqueAsync(entity.ImageUrl))
            throw new InvalidOperationException("Image URL must be unique.");

        await base.UpdateAsync(entity);
    }
}