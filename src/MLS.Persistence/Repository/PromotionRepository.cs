using MLS.Application.Contracts.Persistence;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class PromotionRepository : GenericRepository<Promotion>, IPromotionRepository
    {
        public PromotionRepository(MatLidStoreDatabaseContext context) : base(context)
        {
        }
    }
}