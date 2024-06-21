using MLS.Application.Contracts.Persistence.Common;
using MLS.Domain.Entities;

namespace MLS.Application.Contracts.Persistence.IRepositories;

public interface IProductImageRepository : IGenericRepository<ProductImage>
{
    Task<bool> IsImageUrlUniqueAsync(string imageUrl);
}