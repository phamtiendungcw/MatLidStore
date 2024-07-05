using MLS.Application.Contracts.Persistence.IRepositories;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository;

public class ProductTagRepository : GenericRepository<ProductTag>, IProductTagRepository
{
    public ProductTagRepository(MatLidStoreDatabaseContext context) : base(context)
    {
    }
}