using MLS.Application.DTO.User;
using MLS.Domain.Entities;
using System.Linq.Expressions;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IUserRepository
{
    Task CreateAsync(AppUser entity);

    Task DeleteAsync(AppUser entity);

    Task<IReadOnlyList<AppUser>> GetAllAsync(params Expression<Func<AppUser, object>>[] includes);

    Task<AppUser> GetByIdAsync(int id, params Expression<Func<AppUser, object>>[] includes);

    Task<AppUser?> GetUserByUsernameAsync(LoginModel loginUser, params Expression<Func<AppUser, object>>[] includes);

    Task UpdateAsync(AppUser entity);

    Task<bool> UserExists(string username);
}