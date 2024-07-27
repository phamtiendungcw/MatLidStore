using MLS.Domain.Entities;
using System.Linq.Expressions;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IUserRepository
{
    Task<IReadOnlyList<User>> GetAllAsync(params Expression<Func<User, object>>[] includes);

    Task<User> GetByIdAsync(int id, params Expression<Func<User, object>>[] includes);

    Task CreateAsync(User entity);

    Task UpdateAsync(User entity);

    Task DeleteAsync(User entity);
    Task<User?> GetUserByUsernameAsync(string username, params Expression<Func<User, object>>[] includes);
}