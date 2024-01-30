using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}
