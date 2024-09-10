using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IWishListItemRepository : IGenericRepository<WishListItem>
{
    Task<IEnumerable<WishListItem>> GetItemsByWishListIdAsync(int wishListId);
}