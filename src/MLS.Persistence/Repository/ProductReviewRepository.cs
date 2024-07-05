using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class ProductReviewRepository : GenericRepository<ProductReview>, IProductReviewRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public ProductReviewRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ProductReview>> GetReviewsByUserIdAsync(int userId)
    {
        return await _context.ProductReviews.Where(pr => pr.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<ProductReview>> GetReviewsByProductIdAsync(int productId)
    {
        return await _context.ProductReviews.Where(pr => pr.ProductId == productId).ToListAsync();
    }
}