using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public string ContactInformation { get; set; }
        public ICollection<Supply> Supplies { get; set; }
    }
}