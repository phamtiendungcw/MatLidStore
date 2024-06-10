using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class ProductOption : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string OptionName { get; set; }
        public string OptionValue { get; set; }
    }
}