using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public int PaymentMethodId { get; set; }
        public string MethodName { get; set; }
    }
}
