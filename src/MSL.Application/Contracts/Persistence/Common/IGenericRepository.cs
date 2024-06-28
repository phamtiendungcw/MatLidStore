using MLS.Domain.Common;
using System.Linq.Expressions;

namespace MLS.Application.Contracts.Persistence.Common
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);

        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}