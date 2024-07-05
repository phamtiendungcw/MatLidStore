namespace MLS.Application.DTO.Discount;

public class CreateDiscountDto
{
    public string Code { get; set; } = string.Empty;
    public decimal Percentage { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}