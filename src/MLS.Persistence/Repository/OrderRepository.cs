using MLS.Application.Contracts.Persistence;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(MatLidStoreDatabaseContext context) : base(context)
        {
        }
    }
}