using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IShoppingCartItemRepository : IGenericRepository<ShoppingCartItem>
{
    Task<IEnumerable<ShoppingCartItem>> GetItemsByCartIdAsync(int cartId);
}