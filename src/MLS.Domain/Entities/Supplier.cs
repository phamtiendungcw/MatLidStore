using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public Entities.Address Address { get; set; }
        public string Phone { get; set; }
    }
}
