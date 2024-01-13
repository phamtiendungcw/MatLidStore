using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public Entities.Address Address { get; set; }
        public string Phone { get; set; }
    }
}
