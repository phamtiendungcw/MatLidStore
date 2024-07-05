using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class ProductOptionRepository : GenericRepository<ProductOption>, IProductOptionRepository
{
    public ProductOptionRepository(MatLidStoreDatabaseContext context) : base(context)
    {
    }
}