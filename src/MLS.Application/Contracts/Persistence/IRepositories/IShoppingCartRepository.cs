using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IShoppingCartRepository : IGenericRepository<ShoppingCart>
{
    Task<ShoppingCart?> GetCartByUserIdAsync(int userId);
}