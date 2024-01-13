using MLS.Application.Contracts.Persistence;
using MLS.Domain.Entities;
using MLS.Persistence.DatabaseContext;
using MLS.Persistence.Repository.Common;

namespace MLS.Persistence.Repository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(MatLidStoreDatabaseContext context) : base(context)
        {
        }
    }
}