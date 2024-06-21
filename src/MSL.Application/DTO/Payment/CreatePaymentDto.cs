namespace MLS.Application.DTO.Payment
{
    public class CreatePaymentDto
    {
        public string PaymentMethod { get; set; } = string.Empty;
        public decimal AmountPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public int OrderId { get; set; }
    }
}