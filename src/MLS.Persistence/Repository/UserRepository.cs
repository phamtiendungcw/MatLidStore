using Microsoft.EntityFrameworkCore;
using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Application.DTO.User;
using MLS.Application.Exceptions;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;

namespace MLS.Persistence.Repository;

public class UserRepository : IUserRepository
{
    private readonly MatLidStoreDatabaseContext _context;
    private readonly DbSet<AppUser> _entities;

    public UserRepository(MatLidStoreDatabaseContext context)
    {
        _context = context;
        _entities = _context.Set<AppUser>();
    }

    public virtual async Task CreateAsync(AppUser entity)
    {
        if (!await UserExists(entity.UserName))
            throw new InvalidOperationException($"User with username {entity.UserName} already exists.");

        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(AppUser entity)
    {
        _context.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<IReadOnlyList<AppUser>> GetAllAsync(params Expression<Func<AppUser, object>>[] includes)
    {
        var query = _entities.Where(e => !e.IsDeleted);
        foreach (var include in includes) query = query.Include(include);

        return await query.AsNoTracking().ToListAsync();
    }

    public virtual async Task<AppUser> GetByIdAsync(int id, params Expression<Func<AppUser, object>>[] includes)
    {
        IQueryable<AppUser> query = _entities;
        foreach (var include in includes) query = query.Include(include);

        var entity = await query.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && !e.IsDeleted);

        if (entity is null) throw new NotFoundException(typeof(AppUser).ToString(), id);

        return entity;
    }

    public virtual async Task<AppUser?> GetUserByUsernameAsync(LoginModel loginUser, params Expression<Func<AppUser, object>>[] includes)
    {
        IQueryable<AppUser> query = _entities;
        foreach (var include in includes) query = query.Include(include);

        var entity = await query.AsNoTracking().FirstOrDefaultAsync(e => e.UserName == loginUser.Username && !e.IsDeleted);

        if (entity is null) throw new NotFoundException(typeof(AppUser).ToString(), loginUser.Username);

        if (entity.PasswordHash is null || entity.PasswordSalt is null)
            throw new NotFoundException(nameof(entity.UserName), "This account has not registered a password. Please contact the administrator.");

        using var hmac = new HMACSHA512(entity.PasswordSalt);
        var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password)));

        for (var i = 0; i < computedHash.Length; i++)
            if (computedHash[i] != entity.PasswordHash[i])
                throw new UnauthorizedAccessException("Invalid credentials provided.");

        return entity;
    }

    public virtual async Task UpdateAsync(AppUser entity)
    {
        if (!await UserExists(entity.UserName))
            throw new InvalidOperationException($"User with username {entity.UserName} already exists.");

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<bool> UserExists(string username)
    {
        return !await _context.Users.AnyAsync(x => x.UserName.ToLower() == username.ToLower());
    }
}