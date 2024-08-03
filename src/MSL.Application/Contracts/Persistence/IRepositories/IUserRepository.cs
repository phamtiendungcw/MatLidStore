using MLS.Domain.Entities;
using System.Linq.Expressions;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IUserRepository
{
    Task<IReadOnlyList<AppUser>> GetAllAsync(params Expression<Func<AppUser, object>>[] includes);

    Task<AppUser> GetByIdAsync(int id, params Expression<Func<AppUser, object>>[] includes);

    Task CreateAsync(AppUser entity);

    Task UpdateAsync(AppUser entity);

    Task DeleteAsync(AppUser entity);

    Task<AppUser?> GetUserByUsernameAsync(string username, params Expression<Func<AppUser, object>>[] includes);
}