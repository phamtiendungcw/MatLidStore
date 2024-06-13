namespace MLS.Application.DTO.Payment
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public string PaymentMethod { get; set; }
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; } // Order ID (for foreign key reference)
    }
}