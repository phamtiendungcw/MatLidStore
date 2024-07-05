namespace MLS.Application.DTO.Payment;

public class UpdatePaymentDto
{
    public int Id { get; set; }
    public string? PaymentMethod { get; set; }
    public decimal? AmountPaid { get; set; }
    public DateTime? PaymentDate { get; set; }
    public int? OrderId { get; set; }
}