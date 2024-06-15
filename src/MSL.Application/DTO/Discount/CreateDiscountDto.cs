namespace MLS.Application.DTO.Discount
{
    public class CreateDiscountDto
    {
        public string Code { get; set; }
        public decimal Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}