namespace MLS.Application.DTO.Discount
{
    public class DiscountDto
    {
        public int DiscountId { get; set; }
        public string Name { get; set; }
        public decimal DiscountPercentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}