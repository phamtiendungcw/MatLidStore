using MLS.Domain.Common;

namespace MLS.Domain.Entities
{
    public class PaymentMethod : BaseEntity
    {
        public string MethodName { get; set; } = string.Empty;
    }
}