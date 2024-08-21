using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class ArticleRepository : GenericRepository<Article>, IArticleRepository
{
    private readonly MatLidStoreDatabaseContext _context;

    public ArticleRepository(MatLidStoreDatabaseContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Article>> GetArticlesByAuthorAsync(string author)
    {
        return await _context.Articles.Where(a => a.Author == author).ToListAsync();
    }

    public async Task<bool> IsTitleUniqueAsync(string title)
    {
        return !await _context.Articles.AnyAsync(a => a.Title == title);
    }

    public override async Task CreateAsync(Article entity)
    {
        if (!await IsTitleUniqueAsync(entity.Title))
            throw new InvalidOperationException("Article title must be unique.");

        await base.CreateAsync(entity);
    }

    public override async Task UpdateAsync(Article entity)
    {
        if (!await IsTitleUniqueAsync(entity.Title))
            throw new InvalidOperationException("Article title must be unique.");

        await base.UpdateAsync(entity);
    }
}