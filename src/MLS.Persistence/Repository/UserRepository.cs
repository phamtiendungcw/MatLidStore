using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using System.Linq.Expressions;

namespace MLS.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly MatLidStoreDatabaseContext _context;
    private readonly DbSet<User> _entities;

    public UserRepository(MatLidStoreDatabaseContext context)
    {
        _context = context;
        _entities = _context.Set<User>();
    }

    public async Task<IReadOnlyList<User>> GetAllAsync(params Expression<Func<User, object>>[] includes)
    {
        var query = _entities.Where(e => !e.IsDeleted);
        foreach (var include in includes) query = query.Include(include);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<User> GetByIdAsync(int id, params Expression<Func<User, object>>[] includes)
    {
        IQueryable<User> query = _entities;
        foreach (var include in includes) query = query.Include(include);

        var entity = await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

        if (entity is null) throw new NotFoundException(typeof(User).ToString(), id);

        return entity;
    }

    public async Task CreateAsync(User entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(User entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<User?> GetUserByUsernameAsync(string username, params Expression<Func<User, object>>[] includes)
    {
        IQueryable<User> query = _entities;
        foreach (var include in includes) query = query.Include(include);

        var entity = await query.AsNoTracking().FirstOrDefaultAsync(e => e.UserName == username && !e.IsDeleted);

        if (entity is null) throw new NotFoundException(typeof(User).ToString(), username);

        return entity;
    }
}