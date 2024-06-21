using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IWishListRepository : IGenericRepository<WishList>
{
    Task<IEnumerable<WishList>> GetWishListsByUserIdAsync(int userId);
}